using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerAnimetion : MonoBehaviour
{


    Vector3 defaultscale;
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {

        defaultscale = gameObject.transform.localScale;
        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.transform.Rotate(0, 0, 0);
            transform.DOScale(new Vector3(2.0f,0.5f,2.0f),0.3f);

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
