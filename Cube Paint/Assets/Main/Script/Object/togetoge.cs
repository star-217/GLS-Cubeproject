using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togetoge : MonoBehaviour
{
    //Material material;
    //float time;
    //bool flag = false;
    //[SerializeField] float toge_time;
    // Start is called before the first frame update
    void Start()
    {
        //material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        //time++;

        //if (time % toge_time == 0)
        //{
        //    if (flag)
        //        flag = false;
        //    else
        //        flag = true;
        //}

        //if (flag)
        //    material.color = Color.red;
        //else
        //    material.color = Color.white;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if (flag)
                Destroy(collision.gameObject);
        }
    }

}
