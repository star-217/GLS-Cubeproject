using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimetion : MonoBehaviour
{


    Vector3 defaultscale;
    // Start is called before the first frame update
    void Start()
    {
        defaultscale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            if(gameObject.transform.localScale.x < 1.5 )
            gameObject.transform.localScale += new Vector3(0.05f, 0, 0.05f);
            if (gameObject.transform.localScale.y > 0.5f)
                gameObject.transform.localScale -= new Vector3(0, 0.05f, 0);


        }
        else
        {
            if (gameObject.transform.localScale.x > defaultscale.x)
                gameObject.transform.localScale -= new Vector3(0.1f, 0, 0.1f);
            if (gameObject.transform.localScale.y < defaultscale.y)
                gameObject.transform.localScale += new Vector3(0, 0.1f, 0);
        }
        


    }
}
