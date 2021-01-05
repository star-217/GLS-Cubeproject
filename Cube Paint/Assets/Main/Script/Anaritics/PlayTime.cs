using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayTime : MonoBehaviour
{
    // Start is called before the first frame update
    public static float time;
    int day;
    void Start()
    {
        day = PlayerPrefs.GetInt("Day");
        if (DateUpdated())
        {
            time = 0;
            day += 1;
            PlayerPrefs.SetInt("Day", day);
            // ログインボーナスの処理
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        time += Time.deltaTime;
    }

    private bool DateUpdated()
    {
        DateTime now = DateTime.Now;
        int todayInt = 0;

        todayInt = now.Year * 1000 + now.Month * 100 + now.Day;



        if (!PlayerPrefs.HasKey("Date"))
        {
            Debug.Log("Dateというデータが存在しません");
            PlayerPrefs.SetInt("Date", todayInt);
        }
        else
        {
            if (todayInt - PlayerPrefs.GetInt("Date") > 0)
            {
                PlayerPrefs.SetInt("Date", todayInt);
                Debug.Log("次の日になりました");
                return true;
            }
            else
            {
                Debug.Log("今日すでにログインしています");
            }

        }

        return false;
    }


    private void OnApplicationQuit()
    {
        GLS.GLSAnalyticsUtility.TrackEvent("PlayTime", "Day" + day, (int)time);
    }
}
