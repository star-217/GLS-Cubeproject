using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour
{
    private ParticleSystem BreakWallParticle;
    private MeshRenderer myMeshRenderer;
    private BoxCollider myBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        BreakWallParticle = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        myMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        myBoxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myMeshRenderer.enabled = false;
            myBoxCollider.enabled = false;
            BreakWallParticle.Play();
            //Destroy(gameObject);
        }
    }
   
}
