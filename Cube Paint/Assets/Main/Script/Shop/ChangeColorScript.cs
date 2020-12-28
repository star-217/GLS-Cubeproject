using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//namespace PLAYERCOLOR
//{
    public class ChangeColorScript : MonoBehaviour
    {

        public enum TextureChange
        {
            Blue,
            Red,
            Green,
            Yellow,
            Purple,
            YellowGreen,
            Black,
            Brown,
            LightBlue,
            MAX
        }

    public TextureChange texture_change;
    public int texture_number;
    Button ColorButton;
    public GameObject player;
    public Material material;
    public static Color player_color;
    public static int colorNumber = 1;
   

    // Start is called before the first frame update
    void Start()
    {
            ColorButton = GetComponent<Button>();
            ColorButton.onClick.AddListener(OnclickScene);

            colorNumber = PlayerPrefs.GetInt("ColorNumber");
    }

    // Update is called once per frame
    void Update()
        {
         texture_number = (int)texture_change;
        }

        void OnclickScene()
        {
            if (texture_change == TextureChange.Blue)
            {
            //material.SetColor("_BaseColor", Color.blue);
            colorNumber = 0;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);
            }

            if (texture_change == TextureChange.Red)
            {
            //material.SetColor("_BaseColor", Color.red);
            colorNumber = 1;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }

        if (texture_change == TextureChange.Green)
            {
            //material.SetColor("_BaseColor", Color.green);
            colorNumber = 2;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }

        if (texture_change == TextureChange.Yellow)
            {
            //material.SetColor("_BaseColor", new Color32(255, 255, 0, 255));
            colorNumber = 3;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }

        if (texture_change == TextureChange.Purple)
            {
            //material.SetColor("_BaseColor", new Color32(222, 41, 202, 0));
            colorNumber = 4;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }

        if (texture_change == TextureChange.YellowGreen)
            {
            //material.SetColor("_BaseColor", new Color32(138, 229, 34, 255));
            colorNumber = 5;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }

        if (texture_change == TextureChange.Black)
            {
            //material.SetColor("_BaseColor", Color.black);
            colorNumber = 6;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }

        if (texture_change == TextureChange.Brown)
            {
            //material.SetColor("_BaseColor", new Color32(154, 91, 19, 255));
            colorNumber = 7;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }


        if (texture_change == TextureChange.LightBlue)
            {
            //material.SetColor("_BaseColor", new Color32(48, 225, 227, 255));
            colorNumber = 8;
            PlayerPrefs.SetInt("ColorNumber", colorNumber);

        }

    }
    }
//}
