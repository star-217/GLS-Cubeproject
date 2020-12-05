using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentStageScript : MonoBehaviour
{
    private int stage;

    private TextMeshProUGUI textMeshPro;
    public GameObject CurrentStage_obj;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = CurrentStage_obj.GetComponent<TextMeshProUGUI>();
        stage = PlayerPrefs.GetInt("stage");
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Level " + stage;
    }
}
