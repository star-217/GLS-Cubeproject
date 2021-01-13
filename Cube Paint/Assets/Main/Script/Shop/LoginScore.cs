using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class LoginScore : MonoBehaviour
{
    Button testButton;
    float score;
    public float score_up = 500;
    [SerializeField] GameObject Login;
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("score_save");
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(OnClickBonus);
        rect = GetComponent<RectTransform>();

        rect.DOScale(1.3f, 0.5f).SetLoops(-1,LoopType.Yoyo);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnClickBonus()
    {

        Invoke("PlayerStop", 0.2f);
        if (Login != null)
            Login.SetActive(false);
    }

    void PlayerStop()
    {
         PlayerPrefs.SetInt("Player", 1);
    }

  
}
