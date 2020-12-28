using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BalloonAnime : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    bool flag = false;
    Vector3 pos;
    void Start()
    {
        transform = GetComponent<Transform>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!flag)
        transform.DOMove(pos +new Vector3(0, 0.2f, 0f), 1.0f).OnComplete(() => { flag = true; });
        else
        transform.DOMove(pos, 0.2f).OnComplete(() => { flag = false; });
    }
}
