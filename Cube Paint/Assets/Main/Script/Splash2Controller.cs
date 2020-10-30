using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash2Controller : MonoBehaviour
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
//        transform.position = parent.transform.position;
        transform.rotation = Quaternion.identity;
    }
}
