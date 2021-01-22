using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
using Es.InkPainter.Sample;

public class PlayerEffectScript : MonoBehaviour
{
//    [SerializeField] private GameObject subPlayer;
    public ParticleSystem[] particle;
    private Color color;
    public GameObject ray;
    private GameObject ray_color;

    [SerializeField] private ParticleController particleController = null;

    private Dictionary<string, Quaternion> particleDirection = new Dictionary<string, Quaternion>();

    [System.Obsolete]
    void Start()
    {
        particleDirection.Add("UpWall", Quaternion.Euler(0.0f, 90.0f, 0.0f));
        particleDirection.Add("DownWall", Quaternion.Euler(0.0f, 270.0f, 0.0f));
        particleDirection.Add("RightWall", Quaternion.Euler(0.0f, 180.0f, 0.0f));
        particleDirection.Add("LeftWall", Quaternion.Euler(0.0f, 0.0f, 0.0f));
        particleDirection.Add("Block", Quaternion.Euler(0.0f, 0.0f, 0.0f));

        if (GetComponent<Painter>() != null)
            color = GetComponent<Painter>().SubPaintColor;
        else
            color = GetComponent<PlayerPainter>().GetColor;

        if (gameObject.name == "Player")
            particleController.ParticleColor(0, color);
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (!particleDirection.ContainsKey(collision.gameObject.tag))
            return;

        foreach (var p in collision.contacts)
        {
            particleController.ParticlePlay(0, p.point, particleDirection[collision.gameObject.tag]);
            ray_color = Instantiate(ray, p.point + new Vector3(0, 1.5f, 0), Quaternion.identity);
            var s = ray_color.GetComponent<WallPaint>();
            s.brush.Color = color;
        }
    }
}
