using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOversc : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RectTransform text;
    [SerializeField] RectTransform skip;
    [SerializeField] RectTransform retry;
    public static int gameoverCount; 

    bool flag = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag)
        {
            //if (gameoverCount > 2)
            
                var sequence = DOTween.Sequence();
                sequence.Append(text.DOAnchorPosY(-400.0f, 1.0f));
                sequence.Append(skip.DOScale(1.0f, 0.3f));
                retry.DOScale(1.0f, 0.3f).SetDelay(2.5f);
            
            //else
            //{
            //    var sequence = DOTween.Sequence();
            //    sequence.Append(text.DOAnchorPosY(-300.0f, 0.5f));
            //    sequence.Append(retry.DOScale(1.0f, 0.3f));
            //}


            flag = true;
        }
    }
}
