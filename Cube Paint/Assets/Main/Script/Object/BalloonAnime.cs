using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BalloonAnime : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        transform.DOScale(new Vector3(1.5f,1.5f,1.5f),1.0f);
    }
}
