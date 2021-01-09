using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Es.InkPainter;
using Es.InkPainter.Sample;



public class crystalScript : MonoBehaviour
{

    private TextMeshProUGUI textMeshPro;
    public Inkgauge inkgauge;

  
    [SerializeField] private GameObject next;
    [SerializeField] private GameObject nothanks;
    private NextScene nextScene;
    private NextSceneBonus nextSceneBonus;
    //private float score;
    private float score_save = 0;
    bool scoreFlag = false;
    float score;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro =GetComponent<TextMeshProUGUI>();
        //inkgauge = GameObject.FindGameObjectWithTag("InkGaugeTag").GetComponent<Inkgauge>();
       
        //player = GameObject.FindGameObjectWithTag("Player");
        nextSceneBonus = next.GetComponent<NextSceneBonus>();
        nextScene = nothanks.GetComponent<NextScene>();
        nextScene.ClearEvent.AddListener(StageClear);
        nextSceneBonus.ClearEvent.AddListener(StageClear);

        score_save = PlayerPrefs.GetFloat("score_save");
        //textMeshPro.text = "" + (int)score_save;
        
    }
    // Update is called once per frame
    void Update()
    {

        score_save = PlayerPrefs.GetFloat("score_save");
        textMeshPro.text = "" + (int)score_save;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey("score_save");
            //score_save = 0.0f;
           
        }

      



    }

    private void StageClear(float score)
    {
        score_save += score;//inkgauge.crystal;
        textMeshPro.text = "" + (int)score_save;
        PlayerPrefs.SetFloat("score_save", score_save);
        PlayerPrefs.Save();
    }


}
