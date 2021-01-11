using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBottonMasterScript : MonoBehaviour
{
    static public bool scroll_Change = false; //画面切り替え用
    [SerializeField] private GameObject right_botton;
    [SerializeField] private GameObject left_botton;

    // Start is called before the first frame update
    void Start()
    {
        scroll_Change = false;
        if (!scroll_Change)
            left_botton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //scroll_Changeがfalseの時は一枚目のシーン
        //scroll_Changeがtrueの時は二枚目のシーン
        //コメントのしまい方わかんなかったので後で教えてください(o*。_。)oペコッ

        if (scroll_Change)
        {
            left_botton.SetActive(true);
            right_botton.SetActive(false);
        }
        else
        {
            right_botton.SetActive(true);
            left_botton.SetActive(false);
        }
    }
}
