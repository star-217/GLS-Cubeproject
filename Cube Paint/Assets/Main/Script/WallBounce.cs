using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 velocity;
    public float speed;
    public float power;
    [SerializeField] private float impact = 3.0f;
    stop stopSc;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        stopSc = GetComponent<stop>();
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //
        //if(time > 0.5f)
        //{
        //    time = 0;
        //
        //}
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.back * impact, ForceMode.Impulse);
            return;
        }
        if (collision.gameObject.CompareTag("DownWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.forward * impact, ForceMode.Impulse);
            return;
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.right * impact, ForceMode.Impulse);
            return;
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.left * impact, ForceMode.Impulse);
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
            rigidbody.AddForce(Vector3.back * impact, ForceMode.Impulse);

            return;
        }
        if (collision.gameObject.CompareTag("DownWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.forward * impact, ForceMode.Impulse);
            return;
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power, ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.right * impact, ForceMode.Impulse);

            return;
        }
        if (collision.gameObject.CompareTag("RightWall"))
        {
            // velocity = rigidbody.velocity * speed;
            // rigidbody.velocity = velocity;
            rigidbody.AddForce(rigidbody.velocity.normalized * power,ForceMode.Acceleration);
            rigidbody.AddForce(Vector3.left * impact, ForceMode.Impulse);

            return;
        }
    }
}
