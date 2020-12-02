using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentStageScript : MonoBehaviour
{

    private TextMeshProUGUI textMeshPro;
    public GameObject CurrentStage_obj;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = CurrentStage_obj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Level " + NextScene.stage;
    }
}
