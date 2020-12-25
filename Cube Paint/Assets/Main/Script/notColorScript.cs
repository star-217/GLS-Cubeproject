using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

public class notColorScript : MonoBehaviour
{
    [SerializeField] private Painter painter;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (painter != null)
                painter.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (painter != null)
                painter.enabled = true;
        }
    }
}
