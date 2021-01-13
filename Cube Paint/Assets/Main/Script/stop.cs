using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    Rigidbody rb;
    [HideInInspector] public float time;
    bool flag = false;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      if(playerController.clearFlag == true)       
            rb.velocity = Vector3.zero;
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            time = 0;
    }
}
