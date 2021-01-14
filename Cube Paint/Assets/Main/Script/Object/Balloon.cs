using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Es.InkPainter;

public class Balloon : MonoBehaviour
{
    private ParticleSystem[] particle;

    [SerializeField] private Brush brush = null;
    private CollisionPainter collisionPainter;
    private GameObject player;
    private Material player_material;
    private Color player_color;
    private Color player_color2;
    public  GameObject ray;


    // Start is called before the first frame update
    void Start()
    {
       // obj = GameObject.Find("percent");
        particle = new ParticleSystem[4];
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i< particle.Length; i++) 
        particle[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
    
        collisionPainter = player.GetComponent<CollisionPainter>();
        player_material = player.GetComponent<MeshRenderer>().material;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(PlayerPrefs.GetInt("Vibe") == 1)
                Vibration.Vibrate(90);

            for (int i = 0; i < 4; i++)
                particle[i].Play();

            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            ray.SetActive(true);
        }
    }

   


}
