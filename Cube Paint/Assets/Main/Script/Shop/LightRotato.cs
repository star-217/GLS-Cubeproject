using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightRotato : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        rect.Rotate(new Vector3(0, 0, 40 * Time.deltaTime));

    }
}
