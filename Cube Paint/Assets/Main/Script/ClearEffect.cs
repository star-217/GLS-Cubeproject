using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
using Es.InkPainter.Sample;

public class ClearEffect : MonoBehaviour
{
    GameObject floor;
    GameObject player;
    InkCanvas inkcanvas;
    PlayerController playerController;
    CollisionPainter collisionPainter;
    Rigidbody rigidbody;
    [SerializeField]
    private Brush brush;
    private int waitCount;

    private int wait = 3;


    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.FindGameObjectWithTag("Floor");
        inkcanvas = floor.GetComponent<InkCanvas>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        collisionPainter = player.GetComponent<CollisionPainter>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (inkcanvas.Per > playerController.Clear_Score)
        {
            rigidbody.velocity = new Vector3(0, 0, 50);
        }



    }

    public void FixedUpdate()
    {
        ++waitCount;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (waitCount < wait)
            return;
        waitCount = 0;

        foreach (var p in collision.contacts)
        {
            var canvas = p.otherCollider.GetComponent<InkCanvas>();
            if (canvas != null)
                canvas.Paint(brush, p.point);
        }
    }



}
