using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeScript : MonoBehaviour
{
    [Header("Player_Blueを入れる")]
    public GameObject Player_Blue_Fake;

    [Header("Player_Redを入れる")]
    public GameObject Player_Red_Fake;

    [Header("Player_Greenを入れる")]
    public GameObject Player_Green_Fake;

    [Header("Player_Yellowを入れる")]
    public GameObject Player_Yellow_Fake;

    [Header("Player_Purpleを入れる")]
    public GameObject Player_Purple_Fake;

    [Header("Player_YellowGreenを入れる")]
    public GameObject Player_YellowGreen_Fake;

    [Header("Player_Blackを入れる")]
    public GameObject Player_Black_Fake;

    [Header("Player_Brownを入れる")]
    public GameObject Player_Brown_Fake;

    [Header("Player_LightBlueを入れる")]
    public GameObject Player_LightBlue_Fake;

    private int color_code; 

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("ColorNumber") == 0)
            color_code = 1;
        
           
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("ColorNumber") != 0)
        color_code = PlayerPrefs.GetInt("ColorNumber");

        if (color_code == 1)
        {
            Player_Blue_Fake.SetActive(true);
        }
        else
        {
            Player_Blue_Fake.SetActive(false);
        }

        if (color_code == 2)
        {
            Player_Red_Fake.SetActive(true);
        }
        else
        {
            Player_Red_Fake.SetActive(false);
        }

        if (color_code == 3)
        {
            Player_Green_Fake.SetActive(true);
        }
        else
        {
            Player_Green_Fake.SetActive(false);
        }

        if (color_code == 4)
        {
            Player_Yellow_Fake.SetActive(true);
        }
        else
        {
            Player_Yellow_Fake.SetActive(false);
        }

        if (color_code == 5)
        {
            Player_Purple_Fake.SetActive(true);
        }
        else
        {
            Player_Purple_Fake.SetActive(false);
        }

        if (color_code == 6)
        {
            Player_YellowGreen_Fake.SetActive(true);
        }
        else
        {
            Player_YellowGreen_Fake.SetActive(false);
        }

        if (color_code == 7)
        {
            Player_Black_Fake.SetActive(true);
        }
        else
        {
            Player_Black_Fake.SetActive(false);
        }

        if (color_code == 8)
        {
            Player_Brown_Fake.SetActive(true);
        }
        else
        {
            Player_Brown_Fake.SetActive(false);
        }

        if (color_code == 9)
        {
            Player_LightBlue_Fake.SetActive(true);
        }
        else
        {
            Player_LightBlue_Fake.SetActive(false);
        }
    }
}
