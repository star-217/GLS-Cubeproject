using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMaterialColor : MonoBehaviour
{
    // Start is called before the first frame update
    public enum TextureColor 
    {
        Green,
        Blue,
        Pink
    }


    static public int count;
    public Texture[] sprite;
    public Sprite[] bg;
    public Image image;
    public TextureColor texture;
    public GameObject[] wall;
    int save;

    void Start()
    {

        if (PlayerPrefs.GetInt("StageCount") < 11)
        {

            for (int i = 0; i < wall.Length; i++)
            {
                if (texture == TextureColor.Green)
                {
                    wall[i].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[0]);
                    image.sprite = bg[0];
                }
                if (texture == TextureColor.Blue)
                {
                    wall[i].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[1]);
                    image.sprite = bg[1];
                }
                if (texture == TextureColor.Pink)
                {
                    wall[i].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[2]);
                    image.sprite = bg[2];
                }
            }
        }
        else
        {
            for (int i = 0; i < wall.Length; i++)
            {
                if (count % 3 == 0)
                {
                    wall[i].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[0]);
                    image.sprite = bg[0];
                    texture = TextureColor.Green;
                }
                if (count % 3 == 1)
                {
                    wall[i].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[1]);
                    image.sprite = bg[1];
                    texture = TextureColor.Blue;
                }
                if (count % 3 == 2)
                {
                    wall[i].GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[2]);
                    image.sprite = bg[2];
                    texture = TextureColor.Pink;
                }
            }
            save = count;
            count++;
        }

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Wall");

        foreach (var obj in objects)
        {
                if (obj.GetComponent<MeshRenderer>())
                obj.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[(int)texture]);

            
        }


        GameObject[] objects1 = GameObject.FindGameObjectsWithTag("Block");

        foreach (var obj in objects1)
        {
           
                if (obj.GetComponent<MeshRenderer>())
                obj.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", sprite[(int)texture]);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
