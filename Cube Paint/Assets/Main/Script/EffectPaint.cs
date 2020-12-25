using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class EffectPaint : MonoBehaviour
{
    [SerializeField] private Brush brush;
    int mask = 1 << 10;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, -Vector3.up, out hit, 1000.0f, mask);
        if (hit.collider != null)
        {
            var canvas = hit.collider.gameObject.GetComponent<InkCanvas>();
            canvas.Paint(brush, hit);
        }
    }
}
