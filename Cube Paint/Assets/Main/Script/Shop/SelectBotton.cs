using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBotton : MonoBehaviour
{
    Image image;
    bool flag = false;
    ChangeColorScript colorScript;
    int colorCode;
    Color Co;
    GameObject image_out;
    int useFlag;
    // Start is called before the first frame update
    private void Awake()
    {
        image_out = transform.GetChild(2).gameObject;
        image_out.SetActive(false);
    }
    void Start()
    {
        image = GetComponent<Image>();
        colorScript = GetComponent<ChangeColorScript>();
        Co = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        colorCode = PlayerPrefs.GetInt("ColorNumber");
        useFlag = PlayerPrefs.GetInt("Use");

        if(colorScript.texture_number == useFlag)
        {
            image_out.SetActive(true);
        }
        else
        {
            image_out.SetActive(false);
        }

        if (colorCode == colorScript.texture_number)
        {
            if (!flag)
                image.color -= new Color(0, 0, 0, 0.01f);
            else
                image.color += new Color(0, 0, 0, 0.01f);


            if (image.color.a < 0)
                flag = true;
            if (image.color.a > 1)
                flag = false;

        }
        else
        {

            image.color = Co;
        }

    }
}
