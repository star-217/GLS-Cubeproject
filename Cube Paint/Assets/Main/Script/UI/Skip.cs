using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    private Button button;
    int stage;
    public int maxStage = 43;
    private int stageCount;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnclickScene);

        if (!PlayerPrefs.HasKey("StageCount"))
            PlayerPrefs.SetInt("StageCount", 1);
        else
            stageCount = PlayerPrefs.GetInt("StageCount");
        stage = PlayerPrefs.GetInt("stage", stage);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        stageCount += 1;
        if (stage > maxStage)
        {
            stage = Random.Range(4, maxStage);
        }
        PlayerPrefs.SetInt("stage", stage);
        PlayerPrefs.SetInt("StageCount", stageCount);
        SceneManager.LoadScene("MainStage" + stage);
    }

    private void RewardSuccess()
    {

        

        GLS.GLSAnalyticsUtility.TrackEvent("StageClear", "Stage" + stage, stage);
        stage += 1;
        stageCount += 1;
        if (stageCount > maxStage)
        {
            stage = Random.Range(4, maxStage);
        }
        PlayerPrefs.SetInt("stage", stage);
        PlayerPrefs.SetInt("StageCount", stageCount);
        SceneManager.LoadScene("MainStage" + stage);
    }
}
