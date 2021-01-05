using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplosion : MonoBehaviour
{
    ParticleSystem[] explosion;
    float time;
    bool flag = false; 
    // Start is called before the first frame update
    void Start()
    {
        explosion = new ParticleSystem[transform.childCount];
        for (int i = 0; i < explosion.Length; i++)
            explosion[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;

        if (time > 3)
        {
            if (!flag)
            {
                for (int i = 0; i < transform.childCount; i++)
                    explosion[i].Play();
                flag = true;
            }
        }
        

    }
}
