using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIcontrollerScript : MonoBehaviour
{
    [Header("割合のゲージを入れる")]
    public GameObject PercentageGauge_Object;

    [Header("残りのインク量のゲージを入れる")]
    public GameObject InkRemnantGauge_Object;

    [Header("Titleを入れる")]
    public GameObject Title_Object;

    [Header("TapToStartを入れる")]
    public GameObject TapToStart_Object;

    [Header("ショップを入れる")]
    public GameObject Shop_Object;

    [SerializeField] private GameObject result;

   
    // Start is called before the first frame update
    void Start()
    {
        result.SetActive(false);
        PercentageGauge_Object.SetActive(false);
        InkRemnantGauge_Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

//#if UNITY_EDITOR
//        if (EventSystem.current.IsPointerOverGameObject())
//        {
//            return;
//        }
//#else 
//         if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
//           return;
//         }   
//#endif
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit2D hit2d = Physics2D.Raycast((Vector2)Input.mousePosition, (Vector2)ray.direction);

            //if (!hit2d)
            //{
                
                Shop_Object.SetActive(false);

                Title_Object.SetActive(false);
                TapToStart_Object.SetActive(false);

                PercentageGauge_Object.SetActive(true);
                InkRemnantGauge_Object.SetActive(true);

          //  }
        }
    }
}
