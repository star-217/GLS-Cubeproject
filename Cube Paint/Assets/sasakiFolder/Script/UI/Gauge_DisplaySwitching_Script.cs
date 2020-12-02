using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge_DisplaySwitching_Script : MonoBehaviour
{
    [Header("割合のゲージを入れる")]
    public GameObject PercentageGauge_Object;

    [Header("残りのインク量のゲージを入れる")]
    public GameObject InkRemnantGauge_Object;

    private bool switching = false;


    // Start is called before the first frame update
    void Start()
    {
        PercentageGauge_Object.SetActive(false);
        InkRemnantGauge_Object.SetActive(false);
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
                    PercentageGauge_Object.SetActive(true);
                    InkRemnantGauge_Object.SetActive(true);
                }
                
            }
        }
    }
}
