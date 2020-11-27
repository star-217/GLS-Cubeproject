using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentStageScript : MonoBehaviour
{
    public GameObject CurrentStage_obj;
    private TextMeshProUGUI score_text;

    // Start is called before the first frame update
    void Start()
    {
        score_text = CurrentStage_obj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "level " + NextScene.stage;
    }
}
