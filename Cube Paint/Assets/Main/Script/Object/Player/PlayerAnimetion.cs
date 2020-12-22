using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerAnimetion : MonoBehaviour
{


    Vector3 defaultscale;
    Transform transform;
    Rigidbody rigidbody;

    Vector3 slide;
    Vector3 startPos;
    Vector3 endPos;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {

        defaultscale = gameObject.transform.localScale;
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //slide = rigidbody.velocity;
        //transform.DOScale(defaultscale + (-slide) * 2, 0.01f);

        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }



        if (Input.GetMouseButton(0))
        {
            gameObject.transform.rotation = Quaternion.identity;
            distance = Input.mousePosition - startPos;
            transform.DOScale(defaultscale + new Vector3(0.5f,-0.5f,0.5f),0.3f);

            //if(gameObject.transform.localScale.x < 1.5 )
            //gameObject.transform.localScale += new Vector3(0.05f, 0, 0.05f);
            //if (gameObject.transform.localScale.y > 0.5f)
            //    gameObject.transform.localScale -= new Vector3(0, 0.05f, 0);


        }
        else
        {
            transform.DOScale(defaultscale, 0.1f);
            //if (gameObject.transform.localScale.x > defaultscale.x)
            //    gameObject.transform.localScale -= new Vector3(0.1f, 0, 0.1f);
            //if (gameObject.transform.localScale.y < defaultscale.y)
            //    gameObject.transform.localScale += new Vector3(0, 0.1f, 0);
        }



    }
}
