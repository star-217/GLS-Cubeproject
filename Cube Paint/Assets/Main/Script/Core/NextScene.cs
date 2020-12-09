using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    Button testButton;
    [SerializeField] public static int stage = 1;
    float time;
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
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
    }


    void OnclickScene()
    {
       
        GLS.Ad.ShowInterstitial(0);
        
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
