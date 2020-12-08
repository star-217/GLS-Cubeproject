using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    private Button button;
    int stage;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        stage = PlayerPrefs.GetInt("stage", stage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
          GLS.Ad.ShowInterstitial(1);
        
        GLS.GLSAnalyticsUtility.TrackEvent("StageClear", "Stage" + stage, stage);
        stage += 1;
        if (stage > 20)
        {
            stage = 1;
        }
        PlayerPrefs.SetInt("stage", stage);

        SceneManager.LoadScene("stage"+ stage);

    }
}
