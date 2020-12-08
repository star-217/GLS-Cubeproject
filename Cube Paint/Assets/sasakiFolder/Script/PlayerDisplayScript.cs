using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplayScript : MonoBehaviour
{
    [Header("Player_Blueを入れる")]
    public GameObject Player_Blue;

    [Header("Player_Redを入れる")]
    public GameObject Player_Red;

    [Header("Player_Greenを入れる")]
    public GameObject Player_Green;

    [Header("Player_Yellowを入れる")]
    public GameObject Player_Yellow;

    [Header("Player_Purpleを入れる")]
    public GameObject Player_Purple;

    [Header("Player_YellowGreenを入れる")]
    public GameObject Player_YellowGreen;

    [Header("Player_Blackを入れる")]
    public GameObject Player_Black;

    [Header("Player_Brownを入れる")]
    public GameObject Player_Brown;

    [Header("Player_LightBlueを入れる")]
    public GameObject Player_LightBlue;


    // Start is called before the first frame update
    void Start()
    {
        ChangeColorScript.colorNumber = PlayerPrefs.GetInt("ColorNumber");
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeColorScript.colorNumber == 1)
        {
            Player_Blue.SetActive(true);
        }
        else
        {
            Player_Blue.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 2)
        {
            Player_Red.SetActive(true);
        }
        else
        {
            Player_Red.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 3)
        {
            Player_Green.SetActive(true);
        }
        else
        {
            Player_Green.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 4)
        {
            Player_Yellow.SetActive(true);
        }
        else
        {
            Player_Yellow.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 5)
        {
            Player_Purple.SetActive(true);
        }
        else
        {
            Player_Purple.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 6)
        {
            Player_YellowGreen.SetActive(true);
        }
        else
        {
            Player_YellowGreen.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 7)
        {
            Player_Black.SetActive(true);
        }
        else
        {
            Player_Black.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 8)
        {
            Player_Brown.SetActive(true);
        }
        else
        {
            Player_Brown.SetActive(false);
        }

        if (ChangeColorScript.colorNumber == 9)
        {
            Player_LightBlue.SetActive(true);
        }
        else
        {
            Player_LightBlue.SetActive(false);
        }
    }
}
