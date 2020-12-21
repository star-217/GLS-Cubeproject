using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDraw : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// 物理剛体
    /// </summary>
    private Rigidbody physics = null;

    /// <summary>
    /// 発射方向
    /// </summary>
    [SerializeField]
    private LineRenderer direction = null;

    /// <summary>
    /// 最大付与力量
    /// </summary>
    private const float MaxMagnitude = 4f;

    /// <summary>
    /// 発射方向の力
    /// </summary>
    private float currentForce = 0;

    /// <summary>
    /// メインカメラ
    /// </summary>
    private Camera mainCamera = null;

    /// <summary>
    /// メインカメラ座標
    /// </summary>
    private Transform mainCameraTransform = null;

    /// <summary>
    /// ドラッグ開始点
    /// </summary>
    private Vector3 dragStart = Vector3.zero;

    private Vector3 player_pos;

    Vector3 position;
    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Awake()
    {
        this.physics = this.GetComponent<Rigidbody>();
        this.mainCamera = Camera.main;
        this.mainCameraTransform = this.mainCamera.transform;
    }

    private void Start()
    {
        direction = GetComponent<LineRenderer>();
    }

    /// <summary>
    /// マウス座標をワールド座標に変換して取得
    /// </summary>
    /// <returns></returns>
    /// 

    private void Update()
    {
        player_pos = transform.position;

        if (Input.GetMouseButtonDown(0))
            OnMouseDown();
        if (Input.GetMouseButton(0))
            OnMouseDrag();
        if (Input.GetMouseButtonUp(0))
            OnMouseUp();

    }

    private Vector3 GetMousePosition()
    {
        // マウスから取得できないZ座標を補完する
        position = Input.mousePosition;
        position.z = this.mainCameraTransform.position.z;
        position = this.mainCamera.ScreenToWorldPoint(position);
        position.z = 0;

        return position;
    }

    /// <summary>
    /// ドラック開始イベントハンドラ
    /// </summary>
    public void OnMouseDown()
    {
        this.dragStart = this.GetMousePosition();
        this.direction.enabled = true;
        //this.direction.SetPosition(0, position);
        //this.direction.SetPosition(1, position);
    }

    /// <summary>
    /// ドラッグ中イベントハンドラ
    /// </summary>
    public void OnMouseDrag()
    {
        var dir = this.GetMousePosition();

        this.currentForce = Vector3.Distance(dragStart, dir);
        var ddd = Vector3.Normalize(dragStart - dir);
        ddd.z = ddd.y;
        ddd.y = 0;
        //var cc= (dragStart.y - dir.y);

        var cc = Mathf.Abs(Vector3.Distance(dragStart,dir));

        if ( cc >  MaxMagnitude)
        {
            cc *= MaxMagnitude / cc;
        }
        


        this.direction.SetPosition(0, player_pos);
        this.direction.SetPosition(1, player_pos - ddd * cc);
    }

    /// <summary>
    /// ドラッグ終了イベントハンドラ
    /// </summary>
    public void OnMouseUp()
    {
        this.direction.enabled = false;
    }

}
