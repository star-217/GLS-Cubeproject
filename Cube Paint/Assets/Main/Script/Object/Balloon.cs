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
    private Color player_color2;

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
        player_color2 = player_material.GetColor("_1st_ShadeColor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vibration.Vibrate(100);

            for (int i = 0; i < transform.childCount; i++)
                particle[i].Play();
           
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            collisionPainter.Ink = collisionPainter.Ink_max;
            
            //player.transform.localScale += new Vector3(1, 1, 1);
            //player.transform.position += new Vector3(0, 0.5f, 0);
            
        }
    }

   


}
