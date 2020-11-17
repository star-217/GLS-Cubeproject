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
    private GameObject player;
    private Material player_material;
    private Color player_color;

    // Start is called before the first frame update
    void Start()
    {
       // obj = GameObject.Find("percent");
        particle = new ParticleSystem[transform.childCount];
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i< particle.Length; i++) 
        particle[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
        collisionPainter = player.GetComponent<CollisionPainter>();
        player_material = player.GetComponent<MeshRenderer>().material;
        player_color = player_material.GetColor("_BaseColor");
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

            collisionPainter.Ink = collisionPainter.Ink_max;
            
            player.transform.localScale += new Vector3(1, 1, 1);
            player_material.SetColor("_BaseColor", player_color);
            player_material.SetColor("_1st_ShadeColor", player_color);
            
        }
    }

   
}
