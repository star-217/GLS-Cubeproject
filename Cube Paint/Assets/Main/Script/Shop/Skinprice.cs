using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skinprice : MonoBehaviour
{
    TextMeshProUGUI Text;
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
        if (price != 0)
            Text.text = "" + price;
        else
            Text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
