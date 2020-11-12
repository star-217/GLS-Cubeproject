using Es.InkPainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBOXScript : MonoBehaviour
{
    private GameObject inkCanvas_obj;
    private InkCanvas inkCanvas;

    [Header("ImageGaugeを入れる")]
    public Image cooldown;
    private float gauge_animation;
    private bool gaugeAnimation_control;


    // Start is called before the first frame update
    void Start()
    {
        inkCanvas_obj = GameObject.FindGameObjectWithTag("Floor");
        gaugeAnimation_control = false;
        gauge_animation = 0.001f;
        cooldown.fillAmount = 0;
        inkCanvas = inkCanvas_obj.GetComponent<InkCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown.fillAmount <= inkCanvas.Per / 100)
        {
            gaugeAnimation_control = true;
        }

        if (gaugeAnimation_control)
        {
            cooldown.fillAmount += gauge_animation;
            if (cooldown.fillAmount >= inkCanvas.Per / 100)
            {
                cooldown.fillAmount = inkCanvas.Per / 100;
                gaugeAnimation_control = false;
            }
        }
    }
}
