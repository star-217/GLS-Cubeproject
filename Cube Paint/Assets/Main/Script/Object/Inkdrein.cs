using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inkdrein : MonoBehaviour
{
    private GameObject player;
    private CollisionPainter collisionPainter;
    private MeshRenderer sponge_mesh;
    private MeshRenderer player_mesh;
    private Material sponge_material;
    private Material player_material;
    private Color player_color;
    bool full_flag = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collisionPainter = player.GetComponent<CollisionPainter>();
        sponge_mesh = GetComponent<MeshRenderer>();
        sponge_material = sponge_mesh.material;
        player_mesh = player.GetComponent<MeshRenderer>();
        player_material = player_mesh.material;
        player_color = player_material.GetColor("_BaseColor");
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (full_flag == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collisionPainter.Ink -= collisionPainter.Ink_max * 0.3f;
                sponge_material.SetColor("_BaseColor", player_color);
                sponge_material.SetColor("_1st_ShadeColor", player_color);
                //player_material.SetColor("_BaseColor", Color.white);
                //player_material.SetColor("_1st_ShadeColor", Color.white);
                full_flag = true;

            }
        }
    }
}
