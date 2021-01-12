using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GaugeBOXScript : MonoBehaviour
{
    private GameObject inkCanvas_obj;
    private InkCanvas inkCanvas;

    //[Header("ImageGaugeを入れる")]
    public Image cooldown;
    private float gauge_animation;
    private bool gaugeAnimation_control;

    [SerializeField]
    RectTransform rect;

    [SerializeField] private TimeScript timer;
   


    // Start is called before the first frame update
    void Start()
    {
       
        inkCanvas_obj = GameObject.FindGameObjectWithTag("Floor");
        gaugeAnimation_control = false;
        gauge_animation = 0.01f;
        //cooldown.fillAmount = 0;
        inkCanvas = inkCanvas_obj.GetComponent<InkCanvas>();
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(cooldown.fillAmount <= (inkCanvas.Per / 100)) var targetAmount
        //    cooldown.fillAmount += 0.002f;
        //cooldown.fillAmount = Mathf.Lerp(cooldown.fillAmount, (inkCanvas.Per / 100), 0.01f);
        rect.DOScaleX(timer.time / timer.maxTime, 0.5f);



        //gauge_animation = inkCanvas.Per / 100;

        //rect.DOScaleX(gauge_animation, 1.0f);
    }
}
