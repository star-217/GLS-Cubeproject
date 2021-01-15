using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BalloonAnime : MonoBehaviour
{
    [SerializeField] private Transform transform = null;
    [SerializeField] private SphereCollider sphereCollider = null;
    bool flag = false;
    Vector3 pos;
    
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sphereCollider.enabled)
            return;

        if(!flag)
            transform.DOMove(pos +new Vector3(0, 0.2f, 0f), 1.0f).OnComplete(() => { flag = true; });
        else
            transform.DOMove(pos, 0.2f).OnComplete(() => { flag = false; });
    }
}
