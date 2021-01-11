using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ChangeColorScript : MonoBehaviour
{

     public enum TextureChange
     {
         White,            // 白色のスキン
         Light_Blue,       // 水色のスキン
         Orange,           // オレンジ色のスキン
         SideLine_Green,   // 横線スキンの緑
         SideLine_Blue,    // 横線スキンの青
         SideLine_Pink,    // 横線スキンのピンク
         hurikake_Red,     // 横線スキンの赤
         hurikake_Orange,  // 横線スキンのオレンジ
         tennis,           // テニスボールスキン
         baseball,         // 野球ボールスキン
         Beach_Ball,       // ビーチボールスキン
         Pinball,          // ピンボールスキン
         Skull,            // 骸骨のスキン
         Spiderman_Red,    // スパイダーマンスキン（赤）
         Spiderman_Blue,   // スパイダーマンスキン（青）
         Magma,            // マグマスキン
         MAX
     }

    public TextureChange texture_change;
    public int texture_number;
    Button ColorButton;
    public static Color player_color;
    public static int colorNumber = 1;
    Skinprice Price;
    public float set_score;
    public bool buy_flag = false;
    string name;
    GameObject blackImage;

    // Start is called before the first frame update

    void Start()
    {
        blackImage = transform.GetChild(3).gameObject;

        ColorButton = GetComponent<Button>();
        ColorButton.onClick.AddListener(OnclickScene);
        Price = transform.GetChild(1).gameObject.GetComponent<Skinprice>();
        name = gameObject.name; 


    }
    
    // Update is called once per frame
    void Update()
    {
        colorNumber = PlayerPrefs.GetInt("ColorNumber");
        set_score = PlayerPrefs.GetInt(name);
        texture_number = (int)texture_change;
        if (set_score == 1)
            blackImage.SetActive(false);
    }
    
    void OnclickScene()
    {
      
      

        if (texture_change == TextureChange.White)
            colorNumber = 0;
        if (texture_change == TextureChange.Light_Blue)
            colorNumber = 1;
        if (texture_change == TextureChange.Orange)
            colorNumber = 2;  
        if (texture_change == TextureChange.SideLine_Green)      
            colorNumber = 3;
        if (texture_change == TextureChange.SideLine_Blue)
            colorNumber = 4;
        if (texture_change == TextureChange.SideLine_Pink)
            colorNumber = 5;
        if (texture_change == TextureChange.hurikake_Red)
            colorNumber = 6;  
        if (texture_change == TextureChange.hurikake_Orange)
            colorNumber = 7;
        if (texture_change == TextureChange.tennis)
            colorNumber = 8;
        if (texture_change == TextureChange.baseball)
            colorNumber = 9;
        if (texture_change == TextureChange.Beach_Ball)
            colorNumber = 10;
        if (texture_change == TextureChange.Pinball)
            colorNumber = 11;
        if (texture_change == TextureChange.Skull)
            colorNumber = 12;
        if (texture_change == TextureChange.Spiderman_Red)
            colorNumber = 13;
        if (texture_change == TextureChange.Spiderman_Blue)
            colorNumber = 14;
        if (texture_change == TextureChange.Magma)
            colorNumber = 15;


        if (PlayerPrefs.GetInt("BuyFlag" + colorNumber) == 1)
            PlayerPrefs.SetInt("Use", colorNumber);
       
    }
}

