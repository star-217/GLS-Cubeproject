using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour
{
    private ParticleSystem BreakWallParticle;

    // Start is called before the first frame update
    void Start()
    {
        BreakWallParticle = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BreakWallParticle.Play();
            //Destroy(gameObject);
        }
    }
   
}
