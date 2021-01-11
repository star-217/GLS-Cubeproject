using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoginBonus : MonoBehaviour
{
     float score;
    [SerializeField] GameObject Bonus;
    [SerializeField] GameObject retry;
    int count = 1;
    public int debugcount;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("DateCount"))
        count = PlayerPrefs.GetInt("DateCount");

        if (DateUpdated())
        {
            PlayerPrefs.SetInt("Player", 0);
            Bonus.SetActive(true);
            // ログインボーナスの処理
        }
        else
           PlayerPrefs.SetInt("Player", 1);
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
            PlayerPrefs.SetInt("DateCount", 1);

           
            score += 1000;
            PlayerPrefs.SetFloat("score_save", score);
            return true;
        }
        else
        {
            if (todayInt - PlayerPrefs.GetInt("Date") > 0)
            {
                PlayerPrefs.SetInt("Date", todayInt);
                Debug.Log("次の日になりました");
                count++;
                if (count > 7)
                    count = 1;

                score = PlayerPrefs.GetInt("score_save");
                score += 1000;
                PlayerPrefs.SetFloat("score_save", score);

                PlayerPrefs.SetInt("DateCount", count);
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