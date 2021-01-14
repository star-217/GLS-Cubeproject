using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject[] particles = { null };

    private List<ParticleSystem> particlesList = new List<ParticleSystem>();
    
    private List<GameObject> poolObjList = new List<GameObject>();

    private int objNum = 0;

    Color particleColor;

    void Start()
    {
        foreach (var particle in particles)
        {
            var effect = particle.GetComponent<ParticleSystem>();
            particlesList.Add(effect);
        }
    }

    [System.Obsolete]
    public void ParticlePlay(int particleNum, Vector3 position, Quaternion rotation)
    {
        var effect = GetObject(particleNum);
        effect.transform.position = position;
        effect.transform.rotation = rotation;
    }

    [System.Obsolete]
    public void ParticleColor(int particleNum, Color color)
    {
        var newColor = new ParticleSystem.MinMaxGradient();
        newColor.mode = ParticleSystemGradientMode.Color;
        newColor.color = color;
        particleColor = newColor.color;
    }

    [System.Obsolete]
    void CreatePool(int num, int maxCount) 
    {
        for (int i = 0; i < maxCount; ++i)
        {
            var newObj = GetObject(num);
            newObj.SetActive(false);
            poolObjList.Add(newObj);
        }
    }

    [System.Obsolete]
    public GameObject GetObject(int num)
    {
        objNum = 0;

        // 使用中でないものを探して返す
        foreach (var obj in poolObjList)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                objNum++;
                return obj;
            }
            objNum++;
        }

        // 全て使用中だったら新しく作って返す
        var newObj = CreateNewObject(num);
        newObj.SetActive(true);
        poolObjList.Add(newObj);

        return newObj;
    }

    [System.Obsolete]
    private GameObject CreateNewObject(int num)
    {
        var newObj = Instantiate(particles[num]);
        newObj.name = particles[num].name + (poolObjList.Count + 1);
        var effect = newObj.GetComponent<ParticleSystem>();
        particlesList.Add(effect);
        particlesList[objNum].startColor = particleColor;

        return newObj;
    }
}
