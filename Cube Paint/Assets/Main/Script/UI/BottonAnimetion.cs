using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BottonAnimetion : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    bool flag = false;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!flag)
        {
            rectTransform.DOScale(1.2f, 1.0f).OnComplete(()=>
            {
                flag = true;
            }
                );
        }
        else
        {
            rectTransform.DOScale(1.0f, 0.5f).OnComplete(() =>
            {
                flag = false;
            }
                ); ;
        }


    }
}
