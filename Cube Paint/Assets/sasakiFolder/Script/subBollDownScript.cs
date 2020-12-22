using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subBollDownScript : MonoBehaviour
{
    private Rigidbody myRigidbody; //サブボールのRigidbody
    private Vector3   myPosition;  //サブボールのPosition
    //private float subBall_down = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
        myPosition  = gameObject.GetComponent<Transform>().position;
    }
    // Update is called once per frame
    void Update()
    {
        //if(myPosition.y <= 0.5f)
        //{
        //    myRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        //}
        //subBall_down -= 0.01f;
        //transform.position = new Vector3(0, subBall_down, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "subBallstopTag")
        {
            myRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
