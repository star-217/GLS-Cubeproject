using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;


public class PercentageMasterScript : MonoBehaviour
{
    private InkCanvas[] inkCanvas;
    private GameObject[] inkCanvas_objs;
   // private GameObject inkCanvas_obj;

    public int canvas_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        inkCanvas_objs = GameObject.FindGameObjectsWithTag("Floor");
        inkCanvas = new InkCanvas[inkCanvas_objs.Length];
        for (int i = 0; i < inkCanvas_objs.Length; i++)
        {
            inkCanvas[i] = inkCanvas_objs[i].GetComponent<InkCanvas>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
