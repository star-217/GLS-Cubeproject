using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shock : MonoBehaviour
{

    [SerializeField] ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
    }
}
