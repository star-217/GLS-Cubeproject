using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Inkgauge : MonoBehaviour
{
    public Image gauge;

    private float gauge_animation;
    private bool gaugeAnimation_control;
    private CollisionPainter collisionPainter;
    [SerializeField] private GameObject player;
    float gauge_ink;
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
       
        
    }

    // Update is called once per frame
    void Update()
    {



        //gauge.fillAmount = (collisionPainter.Ink / collisionPainter.Ink_max);
        gauge_ink = (collisionPainter.Ink / collisionPainter.Ink_max);
        rect.DOScaleY(gauge_ink, 0.5f);

    }
}
