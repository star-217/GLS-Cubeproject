using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

public class SetMaterial : MonoBehaviour
{
    [SerializeField] private Painter painter = null;
    [SerializeField] private int materialsNum;
    public int MaterialsNum
    {
        get { return materialsNum; }
    }

    [SerializeField] private Material[] materials;
    [SerializeField] private Color[] colors;

    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = materials[materialsNum];
        painter.SubPaintColor = colors[materialsNum];
    }
}
