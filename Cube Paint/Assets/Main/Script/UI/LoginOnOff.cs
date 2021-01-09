using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginOnOff : MonoBehaviour
{
    public int setCount;
    [SerializeField]GameObject image;
    [SerializeField]GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var count = PlayerPrefs.GetInt("DateCount");

        if (setCount == count)
        {
            image.SetActive(false);
            gameObject.SetActive(true);
        }
        else
        {
            image.SetActive(true);
            gameObject.SetActive(false);
        }


    }
}
