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
        player = GameObject.FindGameObjectsWithTag("Player");
        count = player.Length;
        GLS.Ad.ShowInterstitial(0);

        clearEvent.Invoke(clearScore * count);
        //isClear = true;

        GLS.GLSAnalyticsUtility.TrackEvent("StageClear", "Stage" + stage, stage);
        stage += 1;
        if (stage > 18)
        {
            stage = 1;
        }
        PlayerPrefs.SetInt("stage", stage);

        SceneManager.LoadScene("stage"+ stage);


    }
}
