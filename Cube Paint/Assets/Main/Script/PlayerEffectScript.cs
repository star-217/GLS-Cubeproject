using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
using Es.InkPainter.Sample;

public class PlayerEffectScript : MonoBehaviour
{
    //[SerializeField] private int particleNum;
    private SetMaterial setMaterial;
    [SerializeField] private GameObject subPlayer;
    private int particleNumber;
    public ParticleSystem[] particle;
    //public GameObject ray;
    private GameObject ray_color;
    Color color;

    [SerializeField] private ParticleController particleController = null;

    private Dictionary<string, Quaternion> particleDirection = new Dictionary<string, Quaternion>();

    // Start is called before the first frame update
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

        particleController.ParticleColor(0, color);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (!particleDirection.ContainsKey(collision.gameObject.tag))
            return;

        foreach (var p in collision.contacts)
        {
            particleController.ParticlePlay(0, p.point, particleDirection[collision.gameObject.tag]);
        }
    }
}
