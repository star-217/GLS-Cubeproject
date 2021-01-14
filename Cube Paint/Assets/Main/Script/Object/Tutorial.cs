using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{

    private RectTransform rect;
    private Vector3 position;
    //private float time;
    private float stayTime;
    private Image image;
    bool flag = false;

    private RectTransform Arrow_rectTransform;　　　　//チュートリアルの指のRectTransform
    [SerializeField] private GameObject Arrow_obj;　　//チュートリアルの指のオブジェクト
    private bool arrow_swich = false;

    private int animation_count = 0;//指の動き用
    private Image finger_image;
    private Image arrow_image;
    Sequence sequence;
    Sequence arrow_sequence;
    int bonus;
    // Start is called before the first frame update
    void Start()
    {
        finger_image = GetComponent<Image>();
        arrow_image = Arrow_obj.GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        if (Arrow_obj != null)
            Arrow_rectTransform = Arrow_obj.GetComponent<RectTransform>();

        position = transform.position;
        image = GetComponent<Image>();
        
        sequence = DOTween.Sequence();
        arrow_sequence = DOTween.Sequence();

        bonus = PlayerPrefs.GetInt("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (bonus == 1)
            DrawTutorial();
    }

    void DrawTutorial()
    {
        sequence = DOTween.Sequence();
        arrow_sequence = DOTween.Sequence();

        if (animation_count == 0)
        {
            finger_image.enabled = true;
            arrow_image.enabled = true;
            sequence.Append(rect.DOLocalMoveY(-670.0f, 1.0f));
            sequence.Join(Arrow_rectTransform.DOScale(new Vector3(1, 1, 1), 1.0f))
                .OnComplete(() => {
                    animation_count = 1;
                });

            return;
        }

        if(animation_count == 1)
        {
            sequence.Append(rect.DOLocalMoveX(-100.0f, 1.0f));
            sequence.Join(Arrow_rectTransform.DORotate(new Vector3(0.0f, 0.0f, 70.0f), 1.0f))
                .OnComplete(() => {
                    animation_count = 2;
                });

            return;
        }

        if (animation_count == 2)
        {
            sequence.Append(rect.DOLocalMoveX(100.0f, 1.0f));
            sequence.Join(Arrow_rectTransform.DORotate(new Vector3(0.0f, 0.0f, 110.0f), 1.0f))
                 .OnComplete(() => {
                     animation_count = 3;
                 });

            return;
        }

        if(animation_count == 3)
        {
            finger_image.enabled = false;
            arrow_image.enabled = false;
            sequence.Append(rect.DOLocalMoveY(-500.0f, 1.0f));
            sequence.Join(rect.DOLocalMoveX(0.0f, 1.0f));
            sequence.Join(Arrow_rectTransform.DORotate(new Vector3(0.0f, 0.0f, 90.0f), 1.0f));
            sequence.Join(Arrow_rectTransform.DOScale(new Vector3(0, 1, 1), 1.0f))
                 .OnComplete(() => {
                     animation_count = 0;
                 });

            return;
        }
    }

    private void OnEnable()
    {
        //sequence.Restart();
        //arrow_sequence.Restart();

        animation_count = 0;
        Arrow_rectTransform.DORotate(new Vector3(0.0f, 0.0f, 90.0f), 0.001f);
        Arrow_rectTransform.DOScale(new Vector3(0, 1, 1), 0.001f);
        rect.DOLocalMoveY(-500.0f, 0.001f);
        rect.DOLocalMoveX(0.0f, 0.001f);
    }
}
