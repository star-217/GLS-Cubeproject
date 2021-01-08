using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTime : MonoBehaviour
{
    float time;
    bool flag = false;
    int[] haveSkin;
    int skinCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        for (int i = 0; i < 9; i++)
            haveSkin[i] = PlayerPrefs.GetInt("BuyFlag",+i);

        for (int i = 0; i < 9; i++)
        {
            if (haveSkin[i] == 1)
                skinCount++;
        }

        if (!flag)
        {
            SceneManager.sceneUnloaded += Analitics;
            flag = true;
        }
    }

    void Analitics(Scene thisScene)
    {
        GLS.GLSAnalyticsUtility.TrackEvent("StageTime", "Stage" + PlayerPrefs.GetInt("StageCount"),(int)time);
        GLS.GLSAnalyticsUtility.TrackEvent("HaveSkin", "Stage" + PlayerPrefs.GetInt("StageCount"), skinCount);
        Debug.Log(time);
    }

   
}
