using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movewall : MonoBehaviour
{

    bool move_switch = true;
    Rigidbody rigidbody;
    [SerializeField] private float speed;
    

    enum Mode 
    {
        UpDown,
        RightLeft

    }
    [SerializeField] Mode mode;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.RightLeft)
        {
            if (move_switch)
                rigidbody.velocity = new Vector3(speed, 0, 0);
            else
                rigidbody.velocity = new Vector3(-speed, 0, 0);
        }

        if (mode == Mode.UpDown) 
        {
            if (move_switch)
                rigidbody.velocity = new Vector3(0, 0, speed);
            else
                rigidbody.velocity = new Vector3(0, 0, -speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (move_switch == true)
        {
            if (collision.gameObject.CompareTag("Wall"))
                move_switch = false;
        }
        else
        {
            if (collision.gameObject.CompareTag("Wall"))
                move_switch = true;
        }

        
    }
}
