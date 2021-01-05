using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
    Skinprice Price;
    public float set_score;
    public bool buy_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        ColorButton = GetComponent<Button>();
        ColorButton.onClick.AddListener(OnclickScene);
        Price = transform.GetChild(1).gameObject.GetComponent<Skinprice>();
        set_score = Price.price;
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
            colorNumber = 0;
        if (texture_change == TextureChange.Red)
            colorNumber = 1;
        if (texture_change == TextureChange.Green)
            colorNumber = 2;  
        if (texture_change == TextureChange.Yellow)      
            colorNumber = 3;
        if (texture_change == TextureChange.Purple)
            colorNumber = 4;
        if (texture_change == TextureChange.YellowGreen)
            colorNumber = 5;
        if (texture_change == TextureChange.Black)
            colorNumber = 6;  
        if (texture_change == TextureChange.Brown)
            colorNumber = 7;
        if (texture_change == TextureChange.LightBlue)
            colorNumber = 8;

        if (buy_flag)
            Price.price = 0;

        PlayerPrefs.SetInt("ColorNumber", colorNumber);
        PlayerPrefs.SetFloat("Price", set_score);
    }
}

