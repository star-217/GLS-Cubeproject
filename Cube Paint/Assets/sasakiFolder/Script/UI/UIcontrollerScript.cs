using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontrollerScript : MonoBehaviour
{
    [Header("割合のゲージを入れる")]
    public GameObject PercentageGauge_Object;
    public GameObject Gauge_Outline;



    [Header("TapToStartを入れる")]
    public GameObject TapToStart_Object;

    [Header("ショップを入れる")]
    public GameObject Shop_Object;

    [Header("リザルトを入れる")]
    [SerializeField] private GameObject result;

    [SerializeField] private GameObject Timer;
   
    public GameObject Tutorial;
    public GameObject Arrow;

    private Button testButton;

    static public bool notpaint_swich = false;


    // Start is called before the first frame update
    void Start()
    {
        notpaint_swich = false;
        Gauge_Outline.SetActive(false);
        result.SetActive(false);
        PercentageGauge_Object.SetActive(false);
        //InkRemnantGauge_Object.SetActive(false);

        testButton = Shop_Object.GetComponent<Button>();
        testButton.onClick.AddListener(ShopOnclick);
    }

    // Update is called once per frame

  
    void Update()
    {
#if UNITY_EDITOR
        if (EventSystem.current.IsPointerOverGameObject())
            return;
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 0) return;
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
               return;
            }  
#else
        return;
#endif
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)Input.mousePosition, (Vector2)ray.direction);

            if (!hit2d)
            { 
                ScreenEvent();
            }

        }
    }

    private void ScreenEvent()
    {
        notpaint_swich = true;
        TapToStart_Object.SetActive(false);
        PercentageGauge_Object.SetActive(true);
       // InkRemnantGauge_Object.SetActive(true);
        Gauge_Outline.SetActive(true);
        Shop_Object.SetActive(false);
        if (Timer != null)
            Timer.SetActive(true);
        if (Tutorial != null)
            Tutorial.SetActive(false);
        if (Arrow != null)
            Arrow.SetActive(false);
    }
    void ShopOnclick()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
