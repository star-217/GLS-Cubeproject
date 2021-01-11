using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMaterial : MonoBehaviour
{
    Color color;
    Color color_shader;
    int color_mode;
    Material player_material;
    public Texture[] texture;
    public Material[] material;
    

    // Start is called before the first frame update
    void Start()
    {
        player_material = GetComponent<MeshRenderer>().material;
        color_mode = PlayerPrefs.GetInt("Use");
        PlayerPrefs.SetInt("ColorNumber", color_mode);
       
    }

    // Update is called once per frame
    void Update()
    {
        color_mode = PlayerPrefs.GetInt("Use");

       

        if (color_mode == 0)
            player_material.SetTexture("_MainTex", null);
        if (color_mode == 1)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 2)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 3)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 4)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 5)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 6)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 7)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 8)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 9)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 10)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 11)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 12)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 13)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);
        if (color_mode == 14)
            player_material.SetTexture("_MainTex", texture[color_mode - 1]);

       
    }
}
