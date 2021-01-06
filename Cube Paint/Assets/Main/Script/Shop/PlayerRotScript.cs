using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerRotScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 20*Time.deltaTime, 0));
    }
}
