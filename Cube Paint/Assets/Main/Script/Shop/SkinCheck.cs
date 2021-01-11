using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public int max_skin;
    void Start()
    {
        PlayerPrefs.SetInt("BuyFlag0", 1);
        for (int i = 0; i < max_skin; i++)
        {
            var flag = PlayerPrefs.GetInt("BuyFlag" + i);
            if (flag == 1)
                PlayerPrefs.SetInt("Skin" + i, 1);

            Debug.Log("BuyFlag" + i +" "+ PlayerPrefs.GetInt("BuyFlag" + i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < max_skin; i++)
        {
            var flag = PlayerPrefs.GetInt("BuyFlag" + i);
            if (flag == 1)
                PlayerPrefs.SetInt("Skin" + i, 1);


           
        }
    }
}
