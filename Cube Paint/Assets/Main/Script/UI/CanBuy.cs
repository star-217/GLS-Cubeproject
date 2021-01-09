using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanBuy : MonoBehaviour
{
    // Start is called before the first frame update
    float money;
    public float price = 1000;
    int count;
    int maxCount = 9;
    [SerializeField] GameObject image;
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            if (PlayerPrefs.GetInt("BuyFlag" + i) == 1)
                count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerPrefs.GetFloat("score_save");

        if (count < 9)
            BuyCheck();
       
    }

    void BuyCheck()
    {
        if (money >= price)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
    }
}
