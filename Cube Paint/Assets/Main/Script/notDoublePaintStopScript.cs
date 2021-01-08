using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notDoublePaintStopScript : MonoBehaviour
{
    [SerializeField] private notColorScript notcolorScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (UIcontrollerScript.notpaint_swich)
        {
            notcolorScript.enabled = true;
        }
    }
}
