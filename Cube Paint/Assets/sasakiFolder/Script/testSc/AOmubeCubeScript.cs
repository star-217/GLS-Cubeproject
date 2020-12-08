using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOmubeCubeScript : MonoBehaviour
{
    [SerializeField]
    float speed = 0.05f;
    [SerializeField]
    float max_x = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (transform.position.x > max_x || transform.position.x < -max_x)
        {
            speed *= -1;
        }
    }
}
