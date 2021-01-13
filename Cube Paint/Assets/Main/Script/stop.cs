using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    Rigidbody rb;
    [HideInInspector] public float time;
    bool flag = false;
    [SerializeField] PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(playerController == null)
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.failedFlag == true || playerController.clearFlag == true)
        {
            
             rb.velocity = Vector3.zero;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            time = 0;
    }
}
