using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titleerese : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject text2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            text.SetActive(false);
            text2.SetActive(false);
        }
            
    }
}
