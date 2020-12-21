using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    Rigidbody rb;
    float time;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



        if (rb.velocity.magnitude <= 2.0f)
            rb.velocity = Vector3.zero;


    }
}
