using Es.InkPainter.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inkdrein : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private CollisionPainter collisionPainter;
    private MeshRenderer sponge_mesh;
    private MeshRenderer player_mesh;
    private Material sponge_material;
    private Material player_material;
    private Color player_color;
    // Start is called before the first frame update
    void Start()
    {
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
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionPainter.Ink = 0;
            sponge_material.SetColor("_BaseColor", player_color);
            player_material.SetColor("_BaseColor",Color.white);   


        }
    }
}
