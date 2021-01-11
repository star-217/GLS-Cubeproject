using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialSet : MonoBehaviour
{
    // Start is called before the first frame update
    int texture_mode;
    Material player_material;
    private Color32 white_color = new Color32(255, 255, 255, 255);
    Color color;
    Color color_shader;
    public Texture[] texture;

    void Awake()
    {
        
        player_material = GetComponent<MeshRenderer>().material;

        texture_mode = PlayerPrefs.GetInt("Use");

        if (texture_mode == 0)
            player_material.SetTexture("_MainTex", null);
        if (texture_mode == 1)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 2)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 3)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 4)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 5)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 6)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 7)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 8)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 9)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 10)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 11)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 12)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 13)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);
        if (texture_mode == 14)
            player_material.SetTexture("_MainTex", texture[texture_mode - 1]);


      
    }



    // Update is called once per frame
    void Update()
    {
       


    }
    


}
