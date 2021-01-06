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
    int texture_number;
    public int max_texture;
    
    [SerializeField]private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update


    void Start()
    {
        if (!PlayerPrefs.HasKey("Use"))
            PlayerPrefs.SetInt("Use", 0);

        texture_number = PlayerPrefs.GetInt("ColorNumber"); 
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(Buy);

    }

    // Update is called once per frame
    void Update()
    {
        shop_money = PlayerPrefs.GetFloat("score_save");
        
        texture_number = PlayerPrefs.GetInt("ColorNumber");
        skin_price = PlayerPrefs.GetInt("Skin"+ texture_number);
        var useFlag = PlayerPrefs.GetInt("Use");
        if (skin_price != 0)
            textMeshPro.text = "" + (int)skin_price;
        else if(useFlag == texture_number)
            textMeshPro.text = "Use";
        else
            textMeshPro.text = "Have";
        
    }

    void Buy()
    {

        if (skin_price != 0)
        {
            if (shop_money >= skin_price)
            {
                shop_money -= skin_price;
                PlayerPrefs.SetInt("BuyFlag" + texture_number, 1);
                PlayerPrefs.SetFloat("score_save", shop_money);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Use", texture_number);
           
        }
        
      


    }
}
