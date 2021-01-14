using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject[] particles = { null };

    private List<ParticleSystem> particlesList = new List<ParticleSystem>();

    void Start()
    {
        foreach (var particle in particles)
        {
            var effect = particle.GetComponent<ParticleSystem>();
            particlesList.Add(effect);
        }
    }

    public void ParticlePlay(int particleNum, Vector3 position, Quaternion rotation)
    {
        particles[particleNum].transform.position = position;
        particles[particleNum].transform.rotation = rotation;
        particlesList[particleNum].Play();
    }
}
