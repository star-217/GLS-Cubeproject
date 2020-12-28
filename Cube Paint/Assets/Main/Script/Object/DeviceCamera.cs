using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCamera : MonoBehaviour
{

    Resolution screensize;
    // Start is called before the first frame update
    private void Awake()
    {
        screensize = Screen.currentResolution;
    }
    void Start()
    {
        var height = screensize.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
