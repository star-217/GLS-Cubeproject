using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleForgivenessScript : MonoBehaviour
{
        public static bool matchingSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        matchingSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject); 
    }
}
