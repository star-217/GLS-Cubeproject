using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Resultcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    //public RectTransform star1;
    public RectTransform result;
    //public RectTransform backpanel;
    //public RectTransform text;
    public RectTransform nextButton;
    public RectTransform noThanks;
    bool flag = false;
    bool flag_anime = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == false)
        {
            var sequence = DOTween.Sequence();
            

            //sequence.Append(star1.DOScale(1.0f, 0.3f));
            sequence.Append(result.DOScale(1.0f, 0.3f));
            //sequence.Append(backpanel.DOScale(1.0f, 0.3f));
            //sequence.Append(text.DOScale(1.0f, 0.5f));
            sequence.Append(nextButton.DOScale(1.0f, 0.5f)).OnComplete(BottonAnimetion);

            (noThanks.DOScale(1.0f, 0.5f)).SetDelay(2.5f);

            flag = true;
        }


    }

    void BottonAnimetion()
    {
        var sequence2 = DOTween.Sequence();

        sequence2.Append(nextButton.DOScale(1.2f, 1.0f));
        sequence2.Append(nextButton.DOScale(1.0f, 0.5f)).SetLoops(-1);

    }

   
}
