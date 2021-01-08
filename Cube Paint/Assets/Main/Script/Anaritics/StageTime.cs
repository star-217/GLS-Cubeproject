using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTime : MonoBehaviour
{
    float time;
    bool flag = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
      

        if (!flag)
        {
            SceneManager.sceneUnloaded += Analitics;
            flag = true;
        }
    }

    void Analitics(Scene thisScene)
    {
        GLS.GLSAnalyticsUtility.TrackEvent("StageTime", "Stage" + PlayerPrefs.GetInt("StageCount"),(int)time);
       
        Debug.Log(time);
    }

   
}
