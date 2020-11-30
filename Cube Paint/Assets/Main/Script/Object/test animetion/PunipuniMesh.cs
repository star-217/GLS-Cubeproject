using UnityEngine;
using System.Collections;

/// <summary>
/// ぷにぷにコントローラー用メッシュを保持します。
/// </summary>
public class PunipuniMesh : MonoBehaviour
{
  #region フィールド(private)

  /// <summary>
  /// メッシュ。
  /// </summary>
  Mesh _mesh;

  /// <summary>
  /// オリジナル頂点座標配列(中心以外)
  /// </summary>
  Vector3[] _org_vertexes;

  #endregion

  #region プロパティ

  /// <summary>
  /// 
  /// </summary>
  public Mesh Mesh
  {
    get { return _mesh; }
  }

  /// <summary>
  /// 
  /// </summary>
  public Vector3[] Vertexes
  {
    get
    {
      Vector3[] vtx = new Vector3[_mesh.vertices.Length - 1];
      for( int n = 0; n < vtx.Length; n++ ) {
        vtx[n] = _mesh.vertices[n];
      }
      return vtx;
    }
    set 
    {
      var vtx = _mesh.vertices;
      for( int n = 0; n < value.Length; n++ ) {
        vtx[n] = value[n];
      }
      _mesh.vertices = vtx;
      _mesh.RecalculateBounds();
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public Vector3 CenterPoint
  {
    get
    {
      return _mesh.vertices[_mesh.vertices.Length - 1];
    }
    set
    {
      var vtx = _mesh.vertices;
      vtx[vtx.Length - 1] = value;
      _mesh.vertices = vtx;
      _mesh.RecalculateBounds();
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public Vector3[] OriginalVertexes
  {
    get { return _org_vertexes; }
  }

  #endregion

  /// <summary>
  /// 
  /// </summary>
  /// <param name="vertexCount"></param>
  /// <param name="radius"></param>
  public PunipuniMesh( int vertexCount, float radius )
  {
    CreateMesh(vertexCount, radius);
  }

  /// <summary>
  /// ぷにぷにコントローラー用メッシュを生成します。
  /// </summary>
  /// <param name="vertexCount"></param>
  /// <param name="radius"></param>
  /// <returns></returns>
  bool CreateMesh( int vertexCount, float radius )
  {
    _mesh = new Mesh();

    // 頂点の生成
    Vector3[] points = new Vector3[vertexCount + 1];
    var angle = System.Math.PI * 2;
    for( int n = 0; n < vertexCount; n++ ) {
      var r = angle / vertexCount * n;
      var x = System.Math.Cos(r) * radius;
      var y = System.Math.Sin(r) * radius;
      points[n] = new Vector3((float)x, (float)y, 0);
    }
    points[vertexCount] = new Vector3(0, 0, 0);   // 中心
    _mesh.vertices = points;

    _org_vertexes = new Vector3[points.Length - 1];
    for( int n = 0; n < points.Length - 1; n++ ) {
      _org_vertexes[n] = new Vector3( points[n].x, points[n].y, points[n].z );
    }

    // 頂点インデックス生成
    int[] indexes = new int[vertexCount * 3];
    for( int n = 0; n < vertexCount; n++ ) {
      indexes[n * 3 + 0] = n;
      indexes[n * 3 + 1] = (n + 1) % vertexCount;
      indexes[n * 3 + 2] = vertexCount;
    }
    _mesh.triangles = indexes;

    // 頂点色の生成
    Color[] colors = new Color[vertexCount + 1];
    for( int n = 0; n < vertexCount; n++ ) {
      colors[n] = new Color(1, 1, 1, 1);
    }
    colors[vertexCount] = new Color(0, 0, 0, 0.0f);
    _mesh.colors = colors;

    //_mesh.RecalculateNormals();
    _mesh.RecalculateBounds();

    return true;
  }
}
