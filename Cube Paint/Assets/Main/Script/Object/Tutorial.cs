using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{

    RectTransform rect;
    Vector3 position;
    float time;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        position = transform.position;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 1.0f)
        {
            image.enabled = true;   
            rect.DOLocalMoveY(-670.0f, 0.5f).OnComplete(() =>
            {
                image.enabled = false;
                transform.position = position;
                time = 0;
            }).SetDelay(0.5f);
        }


    }
}
