using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image image;
    [SerializeField] GameObject[] Skin;
    int skin_number;
    void Start()
    {
      
        skin_number = PlayerPrefs.GetInt("Use");
        image.gameObject.transform.parent = Skin[skin_number].transform;
    }

    // Update is called once per frame
    void Update()
    {
        skin_number = PlayerPrefs.GetInt("Use");
        image.transform.parent = Skin[skin_number].transform;
    }
}
