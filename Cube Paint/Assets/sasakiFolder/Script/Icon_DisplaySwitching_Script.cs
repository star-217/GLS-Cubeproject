using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_DisplaySwitching_Script : MonoBehaviour
{
   

    [Header("ショップを入れる")]
    public GameObject Shop_Object;

   // [Header("設定を入れる")]
   // public GameObject Configuration_Object;

    private bool switching = false;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        if (!switching)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)Input.mousePosition, (Vector2)ray.direction);

                if (!hit2d)
                {
                    switching = true;
                    Shop_Object.SetActive(false);
                    //Configuration_Object.SetActive(false);

                  
                }
            }
        }
    }
}
