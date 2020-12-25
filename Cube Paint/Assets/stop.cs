using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    Rigidbody rb;
    [HideInInspector] public float time;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.time;

        if (time >= 3)
        {
            //rb.velocity *= 0.8f;
            if (rb.velocity.magnitude <= 1.0f)
                rb.velocity = Vector3.zero;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            time = 0;
    }
}
