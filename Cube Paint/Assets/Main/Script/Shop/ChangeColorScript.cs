﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    Button ColorButton;
    public GameObject player;
    public Material material;
   // static public Color color;

    // Start is called before the first frame update
    void Start()
    {
        ColorButton = GetComponent<Button>();
        ColorButton.onClick.AddListener(OnclickScene);

        material = player.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnclickScene()
    {
        if (texture_change == TextureChange.Blue)
        {
            material.SetColor("_BaseColor", Color.blue);
        }

        if (texture_change == TextureChange.Red)
        {
            material.SetColor("_BaseColor", Color.red);
        }

        if (texture_change == TextureChange.Green)
        {
            material.SetColor("_BaseColor", Color.green);
        }

        if (texture_change == TextureChange.Yellow)
        {
            material.SetColor("_BaseColor", new Color32(255,255,0,255));
        }

        if (texture_change == TextureChange.Purple)
        {
            material.SetColor("_BaseColor", new Color32(222,41,202,0));
        }

        if (texture_change == TextureChange.YellowGreen)
        {
            material.SetColor("_BaseColor", new Color32(138,229,34,255));
        }

        if (texture_change == TextureChange.Black)
        {
            material.SetColor("_BaseColor", Color.black);
        }

        if (texture_change == TextureChange.Brown)
        {
            material.SetColor("_BaseColor", new Color32(154,91,19,255));
        }

        if (texture_change == TextureChange.LightBlue)
        {
            material.SetColor("_BaseColor", new Color32(48,225,227,255));
        }



    }
}
