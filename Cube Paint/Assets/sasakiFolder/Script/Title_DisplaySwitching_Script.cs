using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_DisplaySwitching_Script : MonoBehaviour
{
    [Header("Titleを入れる")]
    public GameObject Title_Object;

    [Header("TapToStartを入れる")]
    public GameObject TapToStart_Object;

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
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit2d = Physics2D.Raycast((Vector2)Input.mousePosition, (Vector2)ray.direction);

                    if (!hit2d)
                    {
                        switching = true;
                        Title_Object.SetActive(false);
                        TapToStart_Object.SetActive(false);
                    }

                }
               
            }
        }
    }
}
