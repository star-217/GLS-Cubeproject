using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    RectTransform rectButton;

    public GameObject skinBox;
    RectTransform rect;

    public GameObject buyBox;
    RectTransform buyRect;
    //private bool Change_Screen = false; //画面を左右に動かすための変数
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickScroll);
        rect = skinBox.GetComponent<RectTransform>();
        rectButton = GetComponent<RectTransform>();
        buyRect = buyBox.GetComponent<RectTransform>();
        rectButton.DOAnchorPosX(480.0f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
       //
    }

    void OnClickScroll()
    {
        rect.DOLocalMoveX(-1080.0f, 0.5f);
        buyRect.DOLocalMoveX(-1080.0f, 0.5f);

        ScrollBottonMasterScript.scroll_Change = true;
    }
}
