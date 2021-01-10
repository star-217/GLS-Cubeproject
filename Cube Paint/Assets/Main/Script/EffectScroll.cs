using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScroll : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.velocity = new Vector3(0, 0, 10);
        transform.position += new Vector3(0, 0, 25.0f * Time.deltaTime);
    }
}
