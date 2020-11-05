using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pull : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 mouseDirection;
    private Rigidbody rb;
    Vector3 explosion = Vector3.zero;//バンパーの跳ね返しの値

    private Vector3 force;

    Vector3 startPos; //タップした場所を記録
    Vector3 endPos;　//指を離した場所を記録
    float dir = 0;
    float time = 0;
    float speed = 0;

    [SerializeField] private float speed_up = 1;
    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得

    }

    // Update is called once per frame
    void Update()
    {

        mouseDirection = (Input.mousePosition - this.screenPoint);
        mouseDirection.z = mouseDirection.y;
        mouseDirection.y = 0;
        mouseDirection = mouseDirection.normalized;

        if (Input.GetMouseButtonDown(0))
        {
            this.screenPoint = Input.mousePosition;
            this.startPos = Input.mousePosition;
           

        }

        if (Input.GetMouseButtonUp(0))
        {
            force = new Vector3(mouseDirection.x, mouseDirection.y, mouseDirection.z);


            this.endPos = Input.mousePosition;
            endPos.z = 0;

            //スワイプした距離を取得する
            this.dir = Mathf.Abs(Vector3.Distance(this.startPos, this.endPos));

            //速度を計算する
            //this.speed = (this.dir / this.time);
            if (dir > 1000)
                dir = 1000;

            //if(speed > 2000)
            //    speed = 2000;

            //rb.AddForce(force);  // 力を加える
            //rb.AddForce(mouseDirection.x * speed, 3, mouseDirection.z * speed);
            //parentPower.shock(mouseDirection, speed);
            rb.AddForceAtPosition(new Vector3(-mouseDirection.x * dir * speed_up, 0, -mouseDirection.z * dir * speed_up), transform.position + new Vector3(0.0f, 0.2f, 0.0f));


        }

    }
}
