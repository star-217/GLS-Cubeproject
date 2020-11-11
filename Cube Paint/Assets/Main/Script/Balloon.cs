using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Balloon : MonoBehaviour
{
 

   
    private ParticleSystem[] particle;
    private ParticleSystem particle2;

    private CollisionPainter collisionPainter;
    [SerializeField] private GameObject player;

  
    // Start is called before the first frame update
    void Start()
    {
       // obj = GameObject.Find("percent");
        particle = new ParticleSystem[transform.childCount];
        for (int i = 0; i< particle.Length; i++) 
        particle[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
        collisionPainter = player.GetComponent<CollisionPainter>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // Handheld.Vibrate();
            for (int i = 0; i < transform.childCount; i++)
                particle[i].Play();
           
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            collisionPainter.Ink += 200;

        }
    }

   
}
