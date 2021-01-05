using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMoney : MonoBehaviour
{
    float shop_money;
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        shop_money = PlayerPrefs.GetFloat("score_save");
        textMeshPro.text = "" + (int)shop_money;
    }
}
