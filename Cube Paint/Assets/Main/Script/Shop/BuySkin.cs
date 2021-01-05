using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BuySkin : MonoBehaviour
{
    Button testButton;
    float shop_money;
    public float skin_price = 1000;
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
        textMeshPro.text = "" + (int)skin_price;
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
