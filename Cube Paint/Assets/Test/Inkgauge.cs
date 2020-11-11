using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inkgauge : MonoBehaviour
{
    public Image gauge;

    private float gauge_animation;
    private bool gaugeAnimation_control;
    private CollisionPainter collisionPainter;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gaugeAnimation_control = false;
        gauge_animation = 0.001f;
        gauge.fillAmount = 1;
        collisionPainter = player.GetComponent<CollisionPainter>();

    }

    // Update is called once per frame
    void Update()
    {



        gauge.fillAmount = (collisionPainter.Ink / collisionPainter.Ink_max);
        


    }
}
