using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BalloonAnimetion : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    bool flag = false;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //gameObject.transform.Rotate()
        //if(!flag)
        //transform.DOScale(0.025f, 0.5f).OnComplete(() => { flag = true; });
        //else
        //transform.DOScale(0.02f, 0.5f).OnComplete(() => { flag = false; });

        
    }
}
