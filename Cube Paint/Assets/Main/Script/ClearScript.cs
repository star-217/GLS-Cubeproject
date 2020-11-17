using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class ClearScript : MonoBehaviour
{
    InkCanvas inkCanvas;
    [SerializeField] private GameObject roller;
 
    // Start is called before the first frame update
    void Start()
    {
        inkCanvas = GetComponent<InkCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inkCanvas.Per > 75)
            Instantiate(roller);

        
    }
}
