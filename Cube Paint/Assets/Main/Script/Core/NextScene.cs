using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Es.InkPainter.Sample;

public class NextScene : MonoBehaviour
{
    
    Button testButton;
    [SerializeField] public static int stage = 1;
    float time;
    GameObject player;
    CollisionPainter collisionPainter;

    public ClearEvent ClearEvent => clearEvent;

    private bool isClear = false;
    private ClearEvent clearEvent = new ClearEvent();

    float save_ink;
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
        player = GameObject.FindGameObjectWithTag("Player");
        collisionPainter = player.GetComponent<CollisionPainter>();

       
        
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        save_ink = collisionPainter.save_ink;
    }


    void OnclickScene()
    {
       

        GLS.Ad.ShowInterstitial(0);

        clearEvent.Invoke(save_ink);
        //isClear = true;

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
