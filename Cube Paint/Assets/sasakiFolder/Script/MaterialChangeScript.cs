//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MaterialChangeScript : MonoBehaviour
//{
//    private Material material;
//    private Color color;
//    public static bool swith = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        material = GetComponent<MeshRenderer>().material;

//        material.SetColor("_BaseColor", Color.blue);
//        color = ChangeColorScript.player_color;

//        if (color != new Color(0.0f, 0.0f, 0.0f, 0.0f))
//        {
//            color = ChangeColorScript.player_color;
//            material.SetColor("_BaseColor", color);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//       color = ChangeColorScript.player_color;
//       material.SetColor("_BaseColor", color);
//    }
    
//}