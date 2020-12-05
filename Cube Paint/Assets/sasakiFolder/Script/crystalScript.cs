using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Es.InkPainter;



public class crystalScript : MonoBehaviour
{

    private TextMeshProUGUI textMeshPro;
    public GameObject crystalTXT_obj;
    public Inkgauge inkgauge;
    private InkCanvas inkCanvas;
    //private float score;
    private float score_save = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = crystalTXT_obj.GetComponent<TextMeshProUGUI>();
        //inkgauge = GameObject.FindGameObjectWithTag("InkGaugeTag").GetComponent<Inkgauge>();
        inkCanvas = GameObject.FindGameObjectWithTag("Floor").GetComponent<InkCanvas>();

        inkgauge.ClearEvent.AddListener(StageClear);

        score_save = PlayerPrefs.GetFloat("score_save");
        //textMeshPro.text = "" + (int)score_save;

    }
    // Update is called once per frame
    void Update()
    {
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
