using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperSc : MonoBehaviour
{
    private GameObject player;
    Vector3 defScale = new Vector3(1, 1, 1);
    Vector3 upScale = new Vector3(1.3f, 1, 1.3f);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.localScale = upScale;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.localScale = defScale;
        }

    }
}
