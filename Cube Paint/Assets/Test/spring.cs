using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class spring : MonoBehaviour
{

    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        transform.DOPunchScale(new Vector3(0.5f, 10.5f), 1.0f);
    }
}
