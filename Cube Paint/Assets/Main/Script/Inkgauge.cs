using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using Es.InkPainter;

public class ClearEvent : UnityEvent<float> { }

public class Inkgauge : MonoBehaviour
{
    public Image gauge;

    private float gauge_animation;
    private bool gaugeAnimation_control;
    private CollisionPainter collisionPainter;
    private GameObject player;
    private crystalScript crystalScript;
    private InkCanvas inkCanvas;
 
   

    float gauge_ink = 0.0f;
    [SerializeField]
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        gaugeAnimation_control = false;
        gauge_animation = 0.001f;
        gauge.fillAmount = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        collisionPainter = player.GetComponent<CollisionPainter>();

        inkCanvas = GameObject.FindGameObjectWithTag("Floor").GetComponent<InkCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //gauge.fillAmount = (collisionPainter.Ink / collisionPainter.Ink_max);
        if (inkCanvas.Per < 90)
        {
            gauge_ink = (collisionPainter.Ink / collisionPainter.Ink_max);
            rect.DOScaleY(gauge_ink, 0.5f);
        }
        else
        {
            //if (!isClear)
            //{
            //    var score = gauge_ink * 100.0f;

            //    clearEvent.Invoke(score);

            //    //PlayerPrefs.SetFloat("crystal", crystal);
            //    isClear = true;
            //}
        }
    }
}

