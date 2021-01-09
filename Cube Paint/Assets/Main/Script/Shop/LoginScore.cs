using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoginScore : MonoBehaviour
{
    Button testButton;
    float score;
    public float score_up = 500;
    [SerializeField] GameObject Login; 

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("score_save");
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(OnClickBonus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnClickBonus()
    {
        

        if (Login != null)
            Login.SetActive(false);
    }

  
}
