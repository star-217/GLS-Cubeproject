using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Es.InkPainter.Sample;

public class NextScene : MonoBehaviour
{
    
    Button testButton;
    public static int stage = 1;
    float time;
    GameObject[] player;
    int count;
    //CollisionPainter collisionPainter;
    public int maxStage = 35;
    private int stageCount;
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
        if (!PlayerPrefs.HasKey("stage"))
            PlayerPrefs.SetInt("stage", 1);

        stage = PlayerPrefs.GetInt("stage");

        if (!PlayerPrefs.HasKey("StageCount"))
            PlayerPrefs.SetInt("StageCount", 1);
        else
            stageCount = PlayerPrefs.GetInt("StageCount");


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

       
        if(stage > 1)
        GLS.Ad.ShowInterstitial(0);

        clearEvent.Invoke(clearScore);
        //isClear = true;

        GLS.GLSAnalyticsUtility.TrackEvent("StageClear", "Stage" + stage, stage);
        stage += 1;
        stageCount += 1;
        if (stageCount > maxStage)
        {
            stage = Random.Range(4, maxStage);
        }
        PlayerPrefs.SetInt("stage", stage);
        PlayerPrefs.SetInt("StageCount", stageCount);
        SceneManager.LoadScene("MainStage"+ stage);


    }
}
