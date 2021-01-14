using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrockVibrateScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("Vibe") == 1)
                Vibration.Vibrate(20);
        }
    }
}
