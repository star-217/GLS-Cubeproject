using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class AdBonus : MonoBehaviour
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

        rect.DOScale(1.3f, 0.5f).SetLoops(-1, LoopType.Yoyo);
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

        Invoke("PlayerStop", 0.2f);
        if (Login != null)
            Login.SetActive(false);
    }

    private void RewardSuccess()
    {
        score += score_up;

        PlayerPrefs.SetFloat("score_save", score);
        Invoke("PlayerStop", 0.2f);
        if (Login != null)
            Login.SetActive(false);
    }


    void PlayerStop()
    {
        PlayerPrefs.SetInt("Player", 1);
    }
}
