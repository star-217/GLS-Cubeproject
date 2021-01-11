using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Page : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Image image2;
    RectTransform rect;
    RectTransform rect2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ScrollBottonMasterScript.scroll_Change == false)
        {
            image.color = new Color32(255, 255, 255, 255);
            image2.color = new Color32(255, 255, 255, 100);
        }
        if(ScrollBottonMasterScript.scroll_Change == true)
        {
            image.color = new Color32(255, 255, 255, 100);
            image2.color = new Color32(255, 255, 255, 255);
        }

    }
}
