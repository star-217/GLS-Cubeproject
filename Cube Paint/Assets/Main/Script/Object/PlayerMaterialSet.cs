using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialSet : MonoBehaviour
{
    // Start is called before the first frame update
    int color_mode;
    Material player_material;
    private Color32 white_color = new Color32(255, 255, 255, 255);
    Color color;
    Color color_shader;


    void Start()
    {
        
        player_material = GetComponent<MeshRenderer>().material;

        color_mode = PlayerPrefs.GetInt("ColorNumber");

        if (color_mode == 0)
        {
            ColorUtility.TryParseHtmlString("#553CCF", out color);
            ColorUtility.TryParseHtmlString("#432880", out color_shader);

        }

        if (color_mode == 1)
        {
            ColorUtility.TryParseHtmlString("#CA2124", out color);
            ColorUtility.TryParseHtmlString("#B01616", out color_shader);

        }

        if (color_mode == 2)
        {
            ColorUtility.TryParseHtmlString("#009A0E", out color);
            ColorUtility.TryParseHtmlString("#008413", out color_shader);
        }

        if (color_mode == 3)
        {
            ColorUtility.TryParseHtmlString("#ECF11A", out color);
            ColorUtility.TryParseHtmlString("#DBDA54", out color_shader);

        }

        if (color_mode == 4)
        {
            ColorUtility.TryParseHtmlString("#AF60BC", out color);
            ColorUtility.TryParseHtmlString("#854E90", out color_shader);

        }

        if (color_mode == 5)
        {
            ColorUtility.TryParseHtmlString("#96BE38", out color);
            ColorUtility.TryParseHtmlString("#72AB36", out color_shader);

        }

        if (color_mode == 6)
        {
            ColorUtility.TryParseHtmlString("#000000", out color);
            ColorUtility.TryParseHtmlString("#1D1818", out color_shader);

        }

        if (color_mode == 7)
        {
            ColorUtility.TryParseHtmlString("#6A3A1F", out color);
            ColorUtility.TryParseHtmlString("#592D20", out color_shader);

        }

        if (color_mode == 8)
        {
            ColorUtility.TryParseHtmlString("#1F8E9A", out color);
            ColorUtility.TryParseHtmlString("#378689", out color_shader);

        }



        player_material.SetColor("_BaseColor", color);
        player_material.SetColor("_1st_ShadeColor", color_shader);

    }



    // Update is called once per frame
    void Update()
    {
       


    }
    


}
