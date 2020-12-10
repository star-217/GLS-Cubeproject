using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testplayer : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    private Vector3 screenPoint;
    private Vector3 mouseDirection;
    Vector3 startPos; //タップした場所を記録
    Vector3 endPos; //指を離した場所を記録
    float time = 0;
    public float speed = 1;
    private Vector3 force;
    private float dir = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
            this.time = 0;

        }

        //スワイプ中の時間を取得する
        if (Input.GetMouseButton(0))
        {
            this.time += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
            force = new Vector3(mouseDirection.x, mouseDirection.y, mouseDirection.z);


            this.endPos = Input.mousePosition;
            endPos.z = 0;

            //スワイプした距離を取得する
            this.dir = Mathf.Abs(Vector3.Distance(this.startPos, this.endPos));
            Debug.Log(dir);

            //速度を計算する
            //this.speed = (this.dir / this.time);


            //if(speed > 2000)
            //    speed = 2000;

            if (dir >= 200.0f)
            {
                //rb.AddForce(force);  // 力を加える
                rb.AddForce(mouseDirection.x * speed, 0, mouseDirection.z * speed);
                //parentPower.shock(mouseDirection, speed);
                // rb.AddForceAtPosition(new Vector3(mouseDirection.x * speed * speed_up, 0, mouseDirection.z * speed * speed_up), transform.position + new Vector3(0.0f, 0.2f, 0.0f));
            }

        }

    }
}
