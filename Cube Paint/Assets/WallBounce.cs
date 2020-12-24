using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 velocity;
    public float speed;
    public float power;
    stop stopSc;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        stopSc = GetComponent<stop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpWall"))
        {
            velocity = rigidbody.velocity;
            velocity   *= speed;
            velocity.z *= -1.0f;
            stopSc.time = 0;
            return;
        }
        if (collision.gameObject.CompareTag("DownWall"))
        {
            velocity = rigidbody.velocity;
            velocity *= speed;
            velocity.z *= -1.0f;
            stopSc.time = 0;
            return;
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            velocity = rigidbody.velocity;
            velocity *= speed;
            velocity.x *= -1.0f;
            stopSc.time = 0;
            return;
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            velocity = rigidbody.velocity;
            velocity *= speed;
            velocity.x *= -1.0f;
            stopSc.time = 0;
            return;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.back * 3.0f, ForceMode.Impulse);
            return;
        }
        if (collision.gameObject.CompareTag("DownWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.forward * 3.0f, ForceMode.Impulse);
            return;
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.right * 3.0f, ForceMode.Impulse);
            return;
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power,ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.left * 3.0f, ForceMode.Impulse);
            return;
        }
    }
}
