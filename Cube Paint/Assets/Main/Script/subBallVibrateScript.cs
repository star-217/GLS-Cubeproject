using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subBallVibrateScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vibration.Vibrate(5);
        }

        if (collision.gameObject.CompareTag("BreakCubeTag"))
        {
            Vibration.Vibrate(10);
        }

    }
}
