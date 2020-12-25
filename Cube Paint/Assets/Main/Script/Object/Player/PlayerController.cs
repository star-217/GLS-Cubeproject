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

    [SerializeField] GameObject Roller;

    Vector3 startPos; //タップした場所を記録
    Vector3 endPos;　//指を離した場所を記録
    private Vector3 direction;
    private float dir = 0;
    [SerializeField] float clear_score = 75;
    [SerializeField] ParticleSystem end;
    bool end_b = false;


    Vector3 player_pos;
    Vector3 end_pos;
    const float MaxMagnitude = 2.0f;

   // public ParticleSystem balloonparticle;

    public float Dir
    {
        get { return dir; }
    }

    public float Clear_Score 
    {
        get { return clear_score; }
    }

    public float InkRasio
    {
        get { return ink_ratio; }
    }
    //float time = 0;
    float speed = 0;
    [SerializeField] private float speed_up = 1;
   
   

    InkCanvas inkCanvas;
    GameObject floor;
    Vector3 defaultscale;
    Vector3 defaultposition;
    float ink_ratio;
    int ration_change1, ration_change2, ration_change3;
    float high;

    //プレイヤーのインク
    CollisionPainter collisionPainter;
    Color player_color;
    Color player_color2;
    float white;
    bool particle_flag = false;


    [SerializeField] private  GameObject next;
    [SerializeField] private ParticleSystem particle_clear;

    [SerializeField] GameObject Gameover;

    float trail_balance;
    TrailRenderer trailRenderer;

    [SerializeField]GameObject ClearEffect;
    float time;

    //プレイヤーのスピードを増やす変数（12/10）
    [Header("短いときの速度")]
    [SerializeField] private float minimum_speed = 0.0f;

    [Header("長いときの速度")]
    [SerializeField] private float max_speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        //for (int i = 0; i < particle.Length; i++)
        //    particle[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
        floor = GameObject.FindGameObjectWithTag("Floor");
        inkCanvas = floor.GetComponent<InkCanvas>();
        defaultscale = gameObject.transform.localScale;
       // collisionPainter = GetComponent<CollisionPainter>();
        player_color = GetComponent<MeshRenderer>().material.GetColor("_Color");
        defaultposition = gameObject.transform.position;
        //ext = Saveprefab.next;
        //particle_clear = Saveprefab.particle;
        //balloonparticle = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        ration_change1 = 0;
        ration_change2 = ration_change1;
        ration_change3 = ration_change2;
        trailRenderer = GetComponent<TrailRenderer>();
        trail_balance = trailRenderer.startWidth - trailRenderer.endWidth;


        //  Roller.SetActive(false);
    }

   


    // Update is called once per frame
    void Update()
    {
        ink_ratio = 1;/*(collisionPainter.Ink / collisionPainter.Ink_max);*/
        if (ink_ratio > 0.1f)
        {
            PlayerFlick();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        PlayerScaleController(ink_ratio);
        ColorController(ink_ratio);
        //if (defaultscale + 5 < gameObject.transform.localScale.x)
        //{
        //    //for (int i = 0; i < transform.childCount; i++)
        //    //    particle[i].Play();
        //}
    }

    void PlayerFlick()
    {
        if (inkCanvas.Per < 100)
        {
            mouseDirection = (Input.mousePosition - this.screenPoint);
            mouseDirection.z = mouseDirection.y;
            mouseDirection.y = 0;
            mouseDirection = mouseDirection.normalized;

            if (Input.GetMouseButtonDown(0))
            {
                
                rb.velocity = Vector3.zero;

                this.screenPoint = Input.mousePosition;
                this.startPos = Input.mousePosition;

                //this.time = 0;
            }

            //スワイプ中の時間を取得する


            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector3.zero;
                force = new Vector3(mouseDirection.x, mouseDirection.y, mouseDirection.z);

                this.endPos = Input.mousePosition;
                endPos.z = 0;

                //スワイプした距離を取得する
                this.dir = Mathf.Abs(Vector3.Distance(this.startPos, this.endPos));

                //Debug.Log("スワイプ距離" + dir);


                //速度を計算する
                //（スワイプした速度で速さが変わる）
                //this.speed = (this.dir / this.time);

                //if (dir >= 200.0f)
                //{
                //    //rb.AddForce(force);  // 力を加える
                //    rb.AddForce(mouseDirection.x * speed, 0, mouseDirection.z * speed);
                //    //parentPower.shock(mouseDirection, speed);
                //   // rb.AddForceAtPosition(new Vector3(mouseDirection.x * speed * speed_up, 0, mouseDirection.z * speed * speed_up), transform.position + new Vector3(0.0f, 0.2f, 0.0f));
                //}


                if (dir <= 100.0f)
                {
                    rb.AddForce(-mouseDirection.x * minimum_speed, 0, -mouseDirection.z * minimum_speed);
                }
                else if(dir > 100.0f)
                {
                    rb.AddForce(-mouseDirection.x * max_speed, 0, -mouseDirection.z * max_speed);
                }
            }

                if(rb.velocity.magnitude <= 2.0f)
                    rb.velocity = Vector3.zero;
        }
        else
        {
            rb.velocity = Vector3.zero;
            //if (defaultscale + 6 > gameObject.transform.localScale.x)
            //{
            //    gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            //}
           

           
            ClearEffect.SetActive(true);
            time += Time.deltaTime;

            if (time >= 3.0f)
            {
                if (!particle_flag)
                {
                    particle_flag = true;
                    particle_clear.Play();
                }
                next.SetActive(true);

            }
           
           // Roller.SetActive(true);
        }


    }


    void ColorController(float ink_ratio)
    {
        if (ink_ratio < 0.3)
            white = 1.0f;
        else if (ink_ratio < 0.5f)
            white = 0.7f;
        else if (ink_ratio < 0.7f)
            white = 0.4f;
        else if (ink_ratio < 0.9f)
            white = 0.2f;
        else if (ink_ratio > 0.9f)
            white = 0;

        GetComponent<MeshRenderer>().material.SetColor("_Color", player_color * (1.0f - white) + Color.white * white);

    }


    void PlayerScaleController(float ink_ratio)
    {
        //position.y = (ボールの初期Scale.y / 2) * 現在のボールのscale.y
       

        if (ink_ratio > 0.5f)
        {
            gameObject.transform.localScale = defaultscale;
            
        }
        else if (ink_ratio < 0.5f)
        {
           
            if (ink_ratio < 0.3f)
            {
                if (ink_ratio < 0.1f)
                {
                    if (!end_b)
                    {
                        Instantiate(end);
                        GetComponent<MeshRenderer>().enabled = false;
                        Gameover.SetActive(true);
                        end_b = true;
                    }
                }
                else
                {
                    gameObject.transform.localScale = defaultscale * (ink_ratio + 0.2f);
                   
                    high = (defaultscale.y / 2.0f) * gameObject.transform.localScale.y;
                    Vector3 pos;
                    pos.y = high;
                    pos.x = gameObject.transform.position.x;
                    pos.z = gameObject.transform.position.z;

                    gameObject.transform.position = pos;
                    //ration_change2++;
                }
            }

        else
            {
                gameObject.transform.localScale = defaultscale * 0.7f;
                high = (defaultscale.y / 2.0f) * gameObject.transform.localScale.y;/*defaultscale * 0.35f;*/
                ration_change1++;
            }

        }

        trailRenderer.startWidth = gameObject.transform.localScale.x;
        trailRenderer.endWidth = gameObject.transform.localScale.x - trail_balance;
        high = (defaultscale.y / 2.0f) * gameObject.transform.localScale.y;

        if (ration_change1 != ration_change2)
        {
            Vector3 pos;
            pos.y = /*defaultposition.y -*/ high;
            pos.x = gameObject.transform.position.x;
            pos.z = gameObject.transform.position.z;

            gameObject.transform.position = pos;

            ration_change2 = ration_change1;
        }

        if (ration_change2 != ration_change3)
        {
            Vector3 pos;
            pos.y =  high;
            pos.x = gameObject.transform.position.x;
            pos.z = gameObject.transform.position.z;

            gameObject.transform.position = pos;

            ration_change3 = ration_change2;
        }

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

        //if(collision.gameObject.CompareTag("Wall"))
        //{
        //    foreach (var p in collision.contacts)
        //        balloonparticle.Play();

        //}
       
    }



}