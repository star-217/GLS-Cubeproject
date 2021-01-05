﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Es.InkPainter.Sample;

public class NextSceneBonus : MonoBehaviour
{
    
    Button testButton;
    public static int stage = 1;
    float time;
    GameObject[] player;
    int count;
    //CollisionPainter collisionPainter;
    private int maxStage = 10;
    public ClearEvent ClearEvent => clearEvent;

    private bool isClear = false;
    private ClearEvent clearEvent = new ClearEvent();


    [SerializeField]private int clearScore = 10;
    //public int Stage
    //{
    //    get { return stage; }
    //    set { stage = value; }
    //}

    // Start is called before the first frame update
    void Start()
    {
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(OnclickScene);
        stage = PlayerPrefs.GetInt("stage", stage);
       
        
       // collisionPainter = player.GetComponent<CollisionPainter>();



    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        
    }


    void OnclickScene()
    {
        //save_ink = collisionPainter.save_ink;
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
        GLS.GLSAnalyticsUtility.TrackEvent("StageClear", "Stage" + stage, stage);
        stage += 1;
        if (stage > maxStage)
        {
            stage = 1;
        }
        PlayerPrefs.SetInt("stage", stage);

        SceneManager.LoadScene("MainStage" + stage);
    }

    private void RewardSuccess()
    {
        clearEvent.Invoke(clearScore);
        //isClear = true;

        GLS.GLSAnalyticsUtility.TrackEvent("StageClear", "Stage" + stage, stage);
        stage += 1;
        if (stage > maxStage)
        {
            stage = 1;
        }
        PlayerPrefs.SetInt("stage", stage);

        SceneManager.LoadScene("MainStage" + stage);
    }
}