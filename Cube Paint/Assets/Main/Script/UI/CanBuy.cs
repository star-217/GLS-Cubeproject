using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanBuy : MonoBehaviour
{
    // Start is called before the first frame update
    float money;
    public float price = 1000;
    [SerializeField] GameObject image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerPrefs.GetFloat("score_save");

        if(money >= price)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
    }
}
