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
    private InkCanvas inkCanvas;
    [SerializeField] private GameObject next;
    private NextScene nextScene;
    //private float score;
    private float score_save = 0;
    bool scoreFlag = false;
    float score;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro =GetComponent<TextMeshProUGUI>();
        //inkgauge = GameObject.FindGameObjectWithTag("InkGaugeTag").GetComponent<Inkgauge>();
        inkCanvas = GameObject.FindGameObjectWithTag("Floor").GetComponent<InkCanvas>();
        //player = GameObject.FindGameObjectWithTag("Player");
        nextScene = next.GetComponent<NextScene>();
        nextScene.ClearEvent.AddListener(StageClear);

        score_save = PlayerPrefs.GetFloat("score_save");
        //textMeshPro.text = "" + (int)score_save;
        textMeshPro.text = "" + (int)score_save;
    }
    // Update is called once per frame
    void Update()
    {
        

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
