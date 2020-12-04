using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeScript : MonoBehaviour
{
    private Material material;
    private Color color;
   
    // Start is called before the first frame update
    void Start()
    {
        material =GetComponent<MeshRenderer>().material;


        if (color != new Color(0,0,0,0))
        {
            color = ChangeColorScript.player_color;
            material.SetColor("_BaseColor", color);
        }
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}