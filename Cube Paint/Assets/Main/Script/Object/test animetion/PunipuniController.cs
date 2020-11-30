using UnityEngine;
using System.Collections;

/// <summary>
/// ぷにぷにコントローラー
/// </summary>
public class PunipuniController : MonoBehaviour
{
  #region フィールド

  /// <summary>
  /// 描画対象のカメラ
  /// </summary>
  public Camera TargetCamera;

  /// <summary>
  /// 描画対象のマテリアル
  /// </summary>
  public Material Material;

  #endregion

  #region フィールド(private)

  /// <summary>
  /// 半径
  /// </summary>
  float RadiusPixel = 30.0f;
  float Radius;

  /// <summary>
  /// 
  /// </summary>
  PunipuniMesh PuniMesh;

  /// <summary>
  /// 
  /// </summary>
  MeshRenderer Renderer;

  /// <summary>
  /// ベジェ曲線パラメータ(中央、左、右)
  /// </summary>
  Bezier BezierC = new Bezier();
  Bezier BezierL = new Bezier();
  Bezier BezierR = new Bezier();

  /// <summary>
  /// 
  /// </summary>
  Vector3 BeginMousePosition;

  #endregion

  #region プロパティ

  /// <summary>
  /// ぷにぷにコントローラーの表示設定を行います。
  /// </summary>
  private bool VisiblePunipuniController
  {
    get
    {
      if( this.Renderer != null ) {
        return this.Renderer.enabled;
      }
      return false;
    }
    set
    {
      if( this.Renderer != null ) {
        this.Renderer.enabled = value;
      }
    }
  }

  #endregion

  /// <summary>
  /// Use this for initialization
  /// </summary>
  void Start()
  {
    var p1 = TargetCamera.ScreenToWorldPoint(new Vector3(this.RadiusPixel, this.RadiusPixel, transform.position.z));
    var p2 = TargetCamera.ScreenToWorldPoint(new Vector3(-this.RadiusPixel, -this.RadiusPixel, transform.position.z));
    this.Radius = System.Math.Abs(p1.x - p2.x);

    // メッシュを作成しMeshRendererを追加
    PuniMesh = new PunipuniMesh(64, this.Radius);
    AddMeshRenderer(gameObject, this.Material);

    // MeshRendererを保持しておく
    this.Renderer = GetComponent<MeshRenderer>();

    // 非表示
    VisiblePunipuniController = false;
  }

  /// <summary>
  /// Update is called once per frame
  /// </summary>
  void Update()
  {
    if( Input.GetMouseButtonDown(0) ) BeginPunipuni();
    if( Input.GetMouseButtonUp(0) ) EndPunipuni();
    if( Input.GetMouseButton(0) ) TrackingPunipuni();
  }

  /// <summary>
  /// 指定GameObjectにMeshRendererを追加します。
  /// </summary>
  /// <param name="target"></param>
  /// <param name="material"></param>
  void AddMeshRenderer( GameObject target, Material material )
  {
    // メッシュ設定
    var meshFilter = target.AddComponent<MeshFilter>();
    meshFilter.mesh = PuniMesh.Mesh;
    // meshFilter.sharedMesh = this.Mesh;

    // gameObject.AddComponent<MeshCollider>();
    //gameObject.GetComponent<MeshFilter>().sharedMesh.name = name;
    //gameObject.GetComponent<MeshCollider>().sharedMesh = PuniMesh.Mesh;

    { // マテリアル設定
      var renderer = target.AddComponent<MeshRenderer>();
      renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
      renderer.receiveShadows = false;
      renderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
      renderer.material = material;
    }
  }

  /// <summary>
  /// ぷにぷにコントローラーの開始
  /// </summary>
  void BeginPunipuni()
  {
    // 初期位置
    this.BeginMousePosition = TargetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

    // 位置
    transform.position = TargetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

    // 表示
    VisiblePunipuniController = true;

    // ベジェ曲線パラメータ
    var x = 0;
    var y = 0;
    BezierC.P1 = new Vector2(x, y);     // 中心
    BezierC.P2 = new Vector2(x, y);     // 制御点1
    BezierC.P3 = new Vector2(x, y);     // 制御点2
    BezierC.P4 = new Vector2(x, y);     // 終点
    BezierL.P1 = new Vector2(x, y);     // 中心
    BezierL.P2 = new Vector2(x, y);     // 制御点1
    BezierL.P3 = new Vector2(x, y);     // 制御点2
    BezierL.P4 = new Vector2(x, y);     // 終点
    BezierR.P1 = new Vector2(x, y);     // 中心
    BezierR.P2 = new Vector2(x, y);     // 制御点1
    BezierR.P3 = new Vector2(x, y);     // 制御点2
    BezierR.P4 = new Vector2(x, y);     // 終点
  }

  /// <summary>
  /// ぷにぷにコントローラーの終了
  /// </summary>
  void EndPunipuni()
  {
    // 表示
    VisiblePunipuniController = false;
  }

  /// <summary>
  /// ぷにぷにコントローラーの追跡処理
  /// </summary>
  void TrackingPunipuni()
  {
    // ベジェ曲線パラメータの更新
    var pos = TargetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    var x = this.BeginMousePosition.x - pos.x;
    var y = this.BeginMousePosition.y - pos.y;
    UpdateBezierParameter(x, -y);
    // Debug.LogFormat("Mouse X = {0}, y = {1}", Input.mousePosition.x, Input.mousePosition.y);

    // メッシュの更新
    PuniMesh.Vertexes = TransformFromBezier(new Vector3());

    var centerPos = BezierC.GetPosition( 0.8f );
    PuniMesh.CenterPoint = centerPos;
  }

  /// <summary>
  /// ベジェ曲線のパラメータを更新します。
  /// </summary>
  /// <param name="x"></param>
  /// <param name="y"></param>
  private void UpdateBezierParameter( float x, float y )
  {
    AnimateBezierParameter(this.BezierC, this.BezierC, x, y);

    { // 他の2個のベジェの開始位置を更新
      var dir = this.BezierC.P2 - this.BezierC.P1;
      var dirL = new Vector2(dir.y, -dir.x);
      var dirR = new Vector2(-dir.y, dir.x);
      dirL = dirL.normalized;
      dirR = dirR.normalized;
      dirL.x = dirL.x * this.Radius + this.BezierC.P1.x;
      dirL.y = dirL.y * this.Radius + this.BezierC.P1.y;
      dirR.x = dirR.x * this.Radius + this.BezierC.P1.x;
      dirR.y = dirR.y * this.Radius + this.BezierC.P1.y;
      this.BezierL.P1 = dirL;
      this.BezierR.P1 = dirR;
    }

    AnimateBezierParameter(this.BezierL, this.BezierC, x, y);
    AnimateBezierParameter(this.BezierR, this.BezierC, x, y);
  }

  float ArrivalTime = 10; // frame count(本来はtimeがいい)

  /// <summary>
  /// ベジェ曲線パラメータを更新します。
  /// </summary>
  /// <param name="bez"></param>
  /// <param name="baseBez"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  private void AnimateBezierParameter( Bezier bez, Bezier baseBez, float x, float y )
  {
    // 先端点
    bez.P4 = new Vector2(x, y);

    { // 先端制御点
      if( bez.P3 != null ) {
        var vec = baseBez.P1 - bez.P1;
        vec = vec.normalized * (this.Radius / 4);

        var pos = bez.P3 - bez.P4;
        pos += vec;
        pos /= this.ArrivalTime;
        bez.P3 -= pos;
      }
      else {
        bez.P3 = new Vector2(x, y);
      }
    }

    { // 中心制御点
      // 最終的な位置
      var ev = baseBez.P4 - baseBez.P1;
      var len = ev.magnitude;
      ev = ev.normalized;
      ev *= (len / 4);
      ev += bez.P1;

      if( bez.P2 != null ) {
        var v = ev - bez.P2;
        v /= 3; // this.ArrivalTime;
        bez.P2 += v;
        //bez.P2 = ev;
      }
      else {
        bez.P2 = new Vector2(bez.P1.x, bez.P1.y);
      }
    }
  }

  /// <summary>
  /// 操作対象の頂点インデックスを取得します。
  /// </summary>
  /// <param name="center"></param>
  /// <param name="startIndex"></param>
  /// <param name="endIndex"></param>
  void GetMoveFixedVertexIndex( Vector3 center, out int startIndex, out int endIndex )
  {
    Vector3[] points = PuniMesh.OriginalVertexes;

    int sidx = -1;
    int eidx = -1;
    int idx = 0;
    bool recheckStart = true;
    bool recheckEnd = true;
    for( int n = 0; n < points.Length; n++ ) {
      var point = points[n];

      if( BezierL.IsValid ) {
        var PT = point - center;
        var AB = BezierC.P1 - BezierL.P1;
        var c1 = AB.x * PT.y - AB.y * PT.x;
        if( c1 < 0 ) {
          // move
          if( recheckStart ) {
            sidx = idx;
            recheckStart = false;
            recheckEnd = true;
          }
        }
        else {
          // fixed
          if( recheckEnd ) {
            eidx = idx - 1;
            recheckStart = true;
            recheckEnd = false;
          }
        }
      }
      ++idx;
    }
    startIndex = sidx;
    endIndex = eidx;
  }

  /// <summary>
  /// ベジェ曲線パラメータに応じてメッシュを変形します。
  /// </summary>
  /// <param name="center"></param>
  Vector3[] TransformFromBezier( Vector3 center )
  {
    Vector3[] points = PuniMesh.Vertexes;
    Vector3[] org_points = PuniMesh.OriginalVertexes;

    // 操作対象の頂点インデックスを取得
    int si;
    int ei;
    GetMoveFixedVertexIndex(center, out si, out ei);
    if( ei == -1 ) ei = points.Length - 1;
    if( si == -1 || ei == -1 ) {
      return org_points;
    }

    if( si > ei ) ei += points.Length;
    var useCount = ei - si;
    if( useCount <= 0 ) {
      return org_points;
    }

    int centerIdx = (int)(useCount / 2) + si;
    int count1 = centerIdx - si;
    int count2 = ei - centerIdx;
    // Debug.LogFormat("{0}Num, {1}, {2}Num", count1, centerIdx, count2);

    for( int n = 0; n < points.Length; n++ ) {
      points[n] = org_points[n];
    }

    for( int n = 0; n < count1; n++ ) {
      float t = (float)(n + 1) / (float)(count1 + 1);
      var point = BezierL.GetPosition(t);

      // 半径内にある場合はオリジナルを使用する
      var dist = new Vector3(point.x, point.y, center.z) - center;
      var idx = (n + si) % points.Length;
      if( dist.magnitude > this.Radius ) {
        points[idx].x = point.x;
        points[idx].y = point.y;
      }
    }
    for( int n = 0; n < count2; n++ ) {
      float t = (float)(n + 1) / (float)(count2 + 1);
      var point = BezierR.GetPosition(t);

      // 半径内にある場合はオリジナルを使用する
      var dist = new Vector3(point.x, point.y, center.z) - center;
      var idx = (ei - n) % points.Length;
      if( dist.magnitude > this.Radius ) {
        points[idx].x = point.x;
        points[idx].y = point.y;
      }
    }
    {
      // 半径内にある場合はオリジナルを使用する
      var dist = new Vector3(BezierC.P4.x, BezierC.P4.y, center.z) - center;
      var idx = (centerIdx) % points.Length;
      if( dist.magnitude > this.Radius ) {
        // 中心
        points[idx].x = BezierC.P4.x;
        points[idx].y = BezierC.P4.y;
      }
    }
    return points;
  }
}
