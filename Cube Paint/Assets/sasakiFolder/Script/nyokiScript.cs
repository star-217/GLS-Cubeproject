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



    Button option_button;

    private bool switch_option = false;

    // Start is called before the first frame update
    void Start()
    {
        //gauge_animation = 0.1f;
        //cooldown.fillAmount = 0;
        option_button = GetComponent<Button>();
        option_button.onClick.AddListener(OptionClick);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

        

            //rectTran.DOScale(
            //30.0f,  //拡大後の座標
            //1.0f);      //時間

                 // StartCoroutine("Option");
                 // swithi = true;
        }

        //StartCoroutine("Option");
    }

    void OptionClick() 
    {
        if (switch_option == false)
        {
            rectTran.DOScaleY(4.0f, 0.3f);
            
            switch_option = true;
        }
        else
        {
            
            rectTran.DOScaleY(0.0f, 0.3f);
            switch_option = false;
        }
    }

    //IEnumerator Option()
    //{
      
    //    //cooldown.fillAmount += gauge_animation;
    //    yield return new WaitForSeconds(1);
    //}


}
