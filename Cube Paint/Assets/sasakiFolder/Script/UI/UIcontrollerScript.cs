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

    [Header("残りのインク量のゲージを入れる")]
    public GameObject InkRemnantGauge_Object;


    [Header("TapToStartを入れる")]
    public GameObject TapToStart_Object;

    [Header("ショップを入れる")]
    public GameObject Shop_Object;

    [Header("リザルトを入れる")]
    [SerializeField] private GameObject result;

    private Button testButton;


    // Start is called before the first frame update
    void Start()
    {
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
#else
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
            return;
        }
#endif
        if (Input.GetMouseButtonDown(0))
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
        TapToStart_Object.SetActive(false);
        PercentageGauge_Object.SetActive(true);
       // InkRemnantGauge_Object.SetActive(true);
        Gauge_Outline.SetActive(true);
        Shop_Object.SetActive(false);
    }
    void ShopOnclick()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
