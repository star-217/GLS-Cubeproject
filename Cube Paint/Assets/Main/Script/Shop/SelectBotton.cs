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
    [SerializeField] Image randamSelect;
    int useFlag;
    int random;
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
        random = PlayerPrefs.GetInt("Random");
        colorCode = PlayerPrefs.GetInt("ColorNumber");
        useFlag = PlayerPrefs.GetInt("Use");
        var buyFlag = PlayerPrefs.GetInt("BuyFlag" + colorCode);

        //if(buyFlag == 1)
        //{
        //    PlayerPrefs.SetInt("Use", colorCode);
        //}



        if (colorScript.texture_number == useFlag)
        {
            image_out.SetActive(true);
        }
        else
        {
            image_out.SetActive(false);
        }

        if (colorScript.texture_number == random)
        {
            randamSelect.enabled = true;
        }
        else
        {
            randamSelect.enabled = false;
        }

    }
}
