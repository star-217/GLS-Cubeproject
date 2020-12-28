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
    // Start is called before the first frame update
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
