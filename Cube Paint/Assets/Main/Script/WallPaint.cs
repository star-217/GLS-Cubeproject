using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class WallPaint : MonoBehaviour
{
    [SerializeField] public Brush brush;
    int mask = 1 << 10;
    Vector3 position;
    RaycastHit hit;
    float time;
    // Start is called before the first frame update
    
    //public Brush ColorChange
    //{
    //    set { brush = value ; }
    //}


    void Start()
    {
        
        Physics.Raycast(transform.position, -Vector3.up, out hit, 1000.0f, mask);

        if (hit.collider != null)
        {
            var canvas = hit.collider.gameObject.GetComponent<InkCanvas>();
            canvas.Paint(brush, hit);
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject);
    }
}
