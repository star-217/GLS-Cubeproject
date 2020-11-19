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

    private Brush brush;

    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.FindGameObjectWithTag("Floor");
        inkcanvas = floor.GetComponent<InkCanvas>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        collisionPainter = player.GetComponent<CollisionPainter>();
        brush = collisionPainter.Brush;
    }

    // Update is called once per frame
    void Update()
    {
       if(inkcanvas.Per> playerController.Clear_Score)
        {
            rigidbody.velocity = new Vector3(0, 0, 50);
        }


        
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);

        inkcanvas.Paint(brush, hitPos);
     
        }
}
