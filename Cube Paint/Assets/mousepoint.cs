using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mousepoint : MonoBehaviour
{
    // Start is called before the first frame update
    Image image;
    Vector3 mousepos;
    Vector3 worldmouse;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousepos =Input.mousePosition;
            worldmouse = Camera.main.ScreenToWorldPoint(mousepos);
        }
    }
}
