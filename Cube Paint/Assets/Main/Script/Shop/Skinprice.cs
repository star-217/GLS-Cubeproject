using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skinprice : MonoBehaviour
{
    TextMeshProUGUI Text;
    public int price;
    string parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject.name;
        PlayerPrefs.SetInt(parent, price);
    }

    // Update is called once per frame
    void Update()
    {

       price = PlayerPrefs.GetInt(parent);
        Text = GetComponent<TextMeshProUGUI>();
        if (price != 0)
            Text.text = "" + price;
        else
            Text.text = "";
    }
}
