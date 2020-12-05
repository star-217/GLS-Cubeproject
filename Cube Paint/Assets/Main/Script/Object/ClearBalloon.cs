using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBalloon : MonoBehaviour
{

    private ParticleSystem[] particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = new ParticleSystem[transform.childCount];
        for (int i = 0; i < particle.Length; i++)
            particle[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;

        if (collision.gameObject.CompareTag("Floor"))
            for (int i = 0; i < transform.childCount; i++)
                particle[i].Play();

    }
}
