﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Es.InkPainter;
using UnityEngine.SceneManagement;
using Es.InkPainter.Sample;

public struct mVector
{
    public Vector3 pos;
    public bool flag;
}

public class PlayerController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 mouseDirection;
    private Rigidbody rb;
    Vector3 explosion = Vector3.zero;//バンパーの跳ね返しの値
    private ParticleSystem[] particle;
    private Vector3 force;

    Vector3 startPos; //タップした場所を記録
    Vector3 endPos;　//指を離した場所を記録
    private float dir = 0;
    public float Dir
    {
        get { return dir; }
    }

    float time = 0;
    float speed = 0;
    [SerializeField] private float speed_up = 1;
   
   

    InkCanvas inkCanvas;
    GameObject floor;
    float defaultscale;

    //プレイヤーのインク
    CollisionPainter collisionPainter;
    Color player_color;
    Color player_color2;
    float white;





    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        //for (int i = 0; i < particle.Length; i++)
        //    particle[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
        floor = GameObject.FindGameObjectWithTag("Floor");
        inkCanvas = floor.GetComponent<InkCanvas>();
        defaultscale = gameObject.transform.localScale.x;
        collisionPainter = GetComponent<CollisionPainter>();
        player_color = GetComponent<MeshRenderer>().material.GetColor("_BaseColor");
        player_color2 = GetComponent<MeshRenderer>().material.GetColor("_1st_ShadeColor");
    }

   
    // Update is called once per frame
    void Update()
    {

        PlayerFlick();

        ColorController();
        //if (defaultscale + 5 < gameObject.transform.localScale.x)
        //{

        //    //for (int i = 0; i < transform.childCount; i++)
        //    //    particle[i].Play();
        //}





    }

    void PlayerFlick()
    {
        if (inkCanvas.Per < 75)
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
                this.speed = (this.dir / this.time);


                //if(speed > 2000)
                //    speed = 2000;

                if (dir >= 200.0f)
                {
                    //rb.AddForce(force);  // 力を加える
                    //rb.AddForce(mouseDirection.x * speed, 3, mouseDirection.z * speed);
                    //parentPower.shock(mouseDirection, speed);
                    rb.AddForceAtPosition(new Vector3(mouseDirection.x * speed * speed_up, 0, mouseDirection.z * speed * speed_up), transform.position + new Vector3(0.0f, 0.2f, 0.0f));
                }

            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            if (defaultscale + 6 > gameObject.transform.localScale.x)
            {
                gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }


        }


    }


    void ColorController()
    {
        if ((collisionPainter.Ink / collisionPainter.Ink_max < 0.3))
            white = 1.0f;
        else if ((collisionPainter.Ink / collisionPainter.Ink_max < 0.5))
            white = 0.7f;
        else if ((collisionPainter.Ink / collisionPainter.Ink_max < 0.7))
            white = 0.4f;


        GetComponent<MeshRenderer>().material.SetColor("_BaseColor", player_color * (1.0f - white) + Color.white * white);
        GetComponent<MeshRenderer>().material.SetColor("_1st_ShadeColor", player_color2 * (1.0f - white) + Color.white * white);
    }

 

    private void OnCollisionEnter(Collision collision)
    {
        //バンパーの動作
        if (collision.gameObject.CompareTag("Bumper"))
        {
            //explosion = collision.gameObject.transform.forward;
            //Rgd.AddForce(-explosion * 10);
            //バンパーが当たった方向
            explosion = collision.gameObject.transform.position - transform.position;
            explosion.y = 0;
            //バンパーの跳ね返し 
            rb.AddForce(explosion.normalized * 300, ForceMode.Impulse);
        }


       
    }

  




}