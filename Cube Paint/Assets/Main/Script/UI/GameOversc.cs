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

    bool flag = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(text.DOAnchorPosY(-326.0f, 0.8f));
            sequence.Append(skip.DOScale(1.0f, 0.3f));
            retry.DOScale(1.0f, 0.3f).SetDelay(3.0f);
            flag = true;
        }
    }
}
