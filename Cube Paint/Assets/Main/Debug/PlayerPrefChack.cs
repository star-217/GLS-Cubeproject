using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefChack : MonoBehaviour
{
    // Start is called before the first frame update
    int check;
    void Start()
    {
       
            check = PlayerPrefs.GetInt("BuyFlag" + 10);

  
            Debug.Log(check);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
