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
    /// ドラッグ開始点
    /// </summary>
    private Vector3 dragStart = Vector3.zero;

    private Vector3 player_pos;

    Vector3 position;

    private Vector3 screenPoint;
    private Vector3 mouseDirection;

    Vector3 startPos; //タップした場所を記録
    Vector3 endPos; //指を離した場所を記録

    private Vector3 force;

    float dir;
    public float dirMax = 4;

    public void Awake()
    {
        this.physics = this.GetComponent<Rigidbody>();

    }

    private void Start()
    {
        direction = GetComponent<LineRenderer>();
    }



    private void Update()
    {
        player_pos = transform.position;
        player_pos.y = 1.0f;
        mouseDirection = (Input.mousePosition - this.screenPoint);
        mouseDirection.z = mouseDirection.y;
        mouseDirection.y = 0;
        mouseDirection = mouseDirection.normalized;

        if (Input.GetMouseButtonDown(0))
        {

            physics.velocity = Vector3.zero;

            this.screenPoint = Input.mousePosition;
            this.startPos = Input.mousePosition;

            //this.time = 0;
        }

        if (Input.GetMouseButton(0))
        {
            var dragPos = Input.mousePosition;

            //dir = Mathf.Abs(Vector3.Distance(this.startPos,dragPos));


            //if (dirMax < dir)
            //{
            //    dir = dir / dirMax;
            //}
            
                



            direction.enabled = true;

            direction.SetPosition(0,player_pos);
            direction.SetPosition(1, player_pos - mouseDirection * dirMax);

        }

        if (Input.GetMouseButtonUp(0))
        {
            

           
            

            direction.enabled = false;
        }
    }



}
