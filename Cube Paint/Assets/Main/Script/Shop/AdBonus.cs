using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AdBonus : MonoBehaviour
{
    Button testButton;
    float score;
    public float score_up = 500;

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
        if (GLS.Ad.RewardVideoIsReady(0))
        {
            GLS.Ad.ShowRewardedVideo(0, RewardSuccess, AdRewardFailed, AdRewardFailed);
        }
        else
        {
            AdRewardFailed();
        }

    }

    private void AdRewardFailed()
    {
       
       
   
    }

    private void RewardSuccess()
    {
        score += score_up;

        PlayerPrefs.SetFloat("score_save", score);
       
    }
}
