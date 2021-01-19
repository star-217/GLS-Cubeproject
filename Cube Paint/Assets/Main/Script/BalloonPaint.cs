using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class BalloonPaint : MonoBehaviour
{
    [SerializeField] private Brush brush;
    int mask = 1 << 10;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit, 1000.0f, mask))
        {
            var canvas = hit.collider.gameObject.GetComponent<InkCanvas>();
            canvas.Paint(brush, hit);
        }

    }

    // Update is called once per frame
    void Update()
    {

    

        
    }
}
