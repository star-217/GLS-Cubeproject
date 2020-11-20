using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;


public class PercentageMasterAdjustmentScript : MonoBehaviour
{
    private GameObject PercentageMaster_obj;
    private PercentageMasterScript percentageMasterScript;

    private InkCanvas inkCanvas;
    private GameObject inkCanvas_obj;
    // Start is called before the first frame update
    void Start()
    {
        PercentageMaster_obj = GameObject.FindGameObjectWithTag("PercentageTag");
        percentageMasterScript = PercentageMaster_obj.GetComponent<PercentageMasterScript>();

        inkCanvas_obj = GameObject.FindGameObjectWithTag("Floor");
        inkCanvas = inkCanvas_obj.GetComponent<InkCanvas>();

        
    }

    // Update is called once per frame
    void Update()
    {
        inkCanvas.Per *= percentageMasterScript.canvas_count;

    }
}
