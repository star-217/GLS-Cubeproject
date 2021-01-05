using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoginBonus : MonoBehaviour
{
     float score;
    // Start is called before the first frame update
    void Start()
    {
        if (DateUpdated())
        {
            score = PlayerPrefs.GetFloat("score_save");
            score += 1000;
            PlayerPrefs.SetFloat("score_save",score);
            // ログインボーナスの処理
        }
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
}