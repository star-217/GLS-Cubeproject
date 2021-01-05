using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BuySkin : MonoBehaviour
{
    Button testButton;
    float shop_money;
    float skin_price = 1000;
    bool use_flag = false;
    [SerializeField]private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
 
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(Buy);

    }

    // Update is called once per frame
    void Update()
    {
        shop_money = PlayerPrefs.GetFloat("score_save");
        skin_price = PlayerPrefs.GetFloat("Price");
        if (skin_price != 0)
            textMeshPro.text = "" + (int)skin_price;
        else if(use_flag)
            textMeshPro.text = "Use";
        else
            textMeshPro.text = "Have";
    }

    void Buy()
    {
        

        if (shop_money > skin_price)
        {
            shop_money -= skin_price;
            PlayerPrefs.SetFloat("score_save", shop_money);
        }


    }
}
