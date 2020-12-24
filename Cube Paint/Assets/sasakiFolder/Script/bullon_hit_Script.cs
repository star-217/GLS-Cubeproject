using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullon_hit_Script : MonoBehaviour
{
    [SerializeField]
    private Brush brush = null;

    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<MeshRenderer>().material.color = brush.Color;
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnParticleCollision(GameObject other)
    {
        var canvas = other.GetComponent<InkCanvas>();

        if (canvas != null)
        {
            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
            //for (int i = 0; i < numCollisionEvents; i++)
            //{
            Debug.Log(collisionEvents[0].intersection);
                canvas.Paint(brush, collisionEvents[0].intersection);
         //   }

        }
        
    }
}
