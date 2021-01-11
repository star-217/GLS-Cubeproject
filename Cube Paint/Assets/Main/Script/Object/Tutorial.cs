using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{

    private RectTransform rect;
    private Vector3 position;
    private float time;
    private float stayTime;
    private Image image;
    bool flag = false;

    private RectTransform Arrow_rectTransform;　　　　//チュートリアルの指のRectTransform
    [SerializeField] private GameObject Arrow_obj;　　//チュートリアルの指のオブジェクト
    private bool arrow_swich = false;

    private int animation_count = 0;//指の動き用

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        if(Arrow_obj != null)
        Arrow_rectTransform = Arrow_obj.GetComponent<RectTransform>();
        position = transform.position;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Player") == 1)
        DrawTutorial();

    }

    void DrawTutorial()
    {
        //time += Time.deltaTime;
        //stayTime += Time.deltaTime;
        //var sequence = DOTween.Sequence();

        //if (time > 1.0f)
        //{
        //    if (!flag)
        //    {
        //        sequence.Append(Arrow_rectTransform.DOScale(new Vector3(1, 1, 1), 1.0f));
        //        flag = true;
        //    }

        //    image.enabled = true;
        //    sequence.Join(rect.DOLocalMoveY(-670.0f, 1.0f)).OnComplete(() =>
        //    {
        //        sequence.Append(Arrow_rectTransform.DOScale(new Vector3(0, 1, 1), 0.001f));
        //        image.enabled = false;
        //        transform.position = position;
        //        time = 0;
        //        flag = false;
        //    })/*.SetDelay(0.5f)*/;
        //}

        time += Time.deltaTime;
        var sequence = DOTween.Sequence();
        var arrow_sequence = DOTween.Sequence();

        if (time > 1.0f)
        {
            if (animation_count == 0)
            {
                sequence.Append(rect.DOLocalMoveY(-670.0f, 1.0f));
                sequence.Join(Arrow_rectTransform.DOScale(new Vector3(1, 1, 1), 1.0f))
                    .OnComplete(() => {
                        animation_count = 1;
                    });
            }

            if(animation_count == 1)
            {
                sequence.Append(rect.DOLocalMoveX(-100.0f, 1.0f));
                sequence.Join(Arrow_rectTransform.DORotate(new Vector3(0.0f, 0.0f, 70.0f), 1.0f))
                    .OnComplete(() => {
                        animation_count = 2;
                    });
            }

            if(animation_count == 2)
            {
                sequence.Append(rect.DOLocalMoveX(100.0f, 1.0f));
                sequence.Join(Arrow_rectTransform.DORotate(new Vector3(0.0f, 0.0f, 110.0f), 1.0f))
                     .OnComplete(() => {
                         animation_count = 3;
                     });
            }

            if(animation_count == 3)
            {
                sequence.Append(rect.DOLocalMoveY(-500.0f, 1.0f));
                sequence.Join(rect.DOLocalMoveX(0.0f, 1.0f));
                sequence.Join(Arrow_rectTransform.DORotate(new Vector3(0.0f, 0.0f, 90.0f), 1.0f));
                sequence.Join(Arrow_rectTransform.DOScale(new Vector3(0, 1, 1), 1.0f))
                     .OnComplete(() => {
                         animation_count = 0;
                         time = 0.0f;
                     });
            }
        }


    }
}
