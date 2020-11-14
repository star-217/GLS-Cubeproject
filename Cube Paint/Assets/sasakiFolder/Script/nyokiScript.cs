using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class nyokiScript : MonoBehaviour
{
    //[Header("ImageGaugeを入れる")]
    //public Image cooldown;
    //private float gauge_animation;
    //private bool gaugeAnimation_control;

    [SerializeField]
    RectTransform rectTran;

    private bool swithi = false;

    // Start is called before the first frame update
    void Start()
    {
        //gauge_animation = 0.1f;
        //cooldown.fillAmount = 0;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rectTran.DOScaleY(
            3.0f,  //拡大後の座標
            1.0f);

        

            //rectTran.DOScale(
            //30.0f,  //拡大後の座標
            //1.0f);      //時間

                 // StartCoroutine("Option");
                 // swithi = true;
        }

        //StartCoroutine("Option");
    }

    //IEnumerator Option()
    //{
      
    //    //cooldown.fillAmount += gauge_animation;
    //    yield return new WaitForSeconds(1);
    //}


}
