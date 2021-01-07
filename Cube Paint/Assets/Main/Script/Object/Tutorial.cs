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
    private Image image;
    bool flag = false;

    private RectTransform Arrow_rectTransform;　　　　//チュートリアルの指のRectTransform
    [SerializeField] private GameObject Arrow_obj;　　//チュートリアルの指のオブジェクト
    private bool arrow_swich = false;

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
        time += Time.deltaTime;
        var sequence = DOTween.Sequence();

        if (time > 1.0f)
        {
           
            if (!flag)
            {
                sequence.Append(Arrow_rectTransform.DOScale(new Vector3(1, 1, 1), 0.5f));
                flag = true;
            }
               

            image.enabled = true;   
            sequence.Join(rect.DOLocalMoveY(-670.0f, 0.5f)).OnComplete(() =>
            {
                sequence.Append(Arrow_rectTransform.DOScale(new Vector3(0, 1, 1), 0.001f));
                

                image.enabled = false;
                transform.position = position;
                time = 0;
                flag = false;
            }).SetDelay(0.5f);
        }


    }
}
