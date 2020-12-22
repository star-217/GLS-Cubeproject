using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Resultcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform star1;
    public RectTransform star2;
    public RectTransform star3;
    public RectTransform text;
    public RectTransform nextButton;
    public RectTransform noThanks;
    bool flag = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == false)
        {
            var sequence = DOTween.Sequence();

            sequence.Append(star1.DOScale(1.0f, 0.3f));
            sequence.Append(star2.DOScale(1.0f, 0.3f));
            sequence.Append(star3.DOScale(1.0f, 0.3f));
            sequence.Append(text.DOScale(1.0f, 0.5f));
            sequence.Append(nextButton.DOScale(1.0f, 0.3f));
            sequence.Append(noThanks.DOScale(1.0f, 0.3f));

            flag = true;
        }
    }
}
