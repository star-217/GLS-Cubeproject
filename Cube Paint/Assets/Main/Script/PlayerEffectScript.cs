using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
using Es.InkPainter.Sample;

public class PlayerEffectScript : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject ray;
    private GameObject ray_color;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Painter>() != null)
            color = GetComponent<Painter>().SubPaintColor;
        else
            color = GetComponent<PlayerPainter>().GetColor;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpWall"))
        {
            foreach (var p in collision.contacts)
            {
                Instantiate(particle, p.point, Quaternion.Euler(0.0f, 90.0f, 0.0f));
                ray_color = Instantiate(ray, p.point + new Vector3(0,1.5f,0), Quaternion.identity);
                var s = ray_color.GetComponent<WallPaint>();
                s.brush.Color = color;
            }
        }

        if (collision.gameObject.CompareTag("DownWall"))
        {
            foreach (var p in collision.contacts)
            {
                Instantiate(particle, p.point, Quaternion.Euler(0.0f, 270.0f, 0.0f));
                ray_color = Instantiate(ray, p.point + new Vector3(0, 1.5f, 0), Quaternion.identity);
                var s = ray_color.GetComponent<WallPaint>();
                s.brush.Color = color;
            }
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            foreach (var p in collision.contacts)
            {
                Instantiate(particle, p.point, Quaternion.Euler(0.0f,180.0f, 0.0f));
                ray_color = Instantiate(ray, p.point + new Vector3(0, 1.5f, 0), Quaternion.identity);
                var s = ray_color.GetComponent<WallPaint>();
                s.brush.Color = color;
            }
        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            foreach (var p in collision.contacts)
            {
                Instantiate(particle, p.point, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                ray_color = Instantiate(ray, p.point + new Vector3(0, 1.5f, 0), Quaternion.identity);
                var s = ray_color.GetComponent<WallPaint>();
                s.brush.Color = color;
            }
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            foreach (var p in collision.contacts)
            {
                Instantiate(particle, p.point, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                ray_color = Instantiate(ray, p.point + new Vector3(0, 1.5f, 0), Quaternion.identity);
                var s = ray_color.GetComponent<WallPaint>();
                s.brush.Color = color;
            }
        }

    }

  
}
