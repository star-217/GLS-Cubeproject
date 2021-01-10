using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    public GameObject skinBox;
    RectTransform rect;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickScroll);
        rect = skinBox.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickScroll()
    {
        rect.DOLocalMoveX(-1080.0f, 0.5f);
    }
}
