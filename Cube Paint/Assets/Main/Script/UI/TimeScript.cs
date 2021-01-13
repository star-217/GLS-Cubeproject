using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TimeScript : MonoBehaviour
{
    [System.NonSerialized] public float maxTime = 10;
    public float time = 0; // クリアするための時間
    float seconds;
    private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private PlayerController playerController;
    RectTransform rect;
    bool flag = false;
 

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        maxTime = time;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.failedFlag == false && playerController.clearFlag == false)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                textMeshPro.text = "Time:" + time.ToString("00"); //+ ":" + (time-(int)time).ToString(".00").TrimStart('0').TrimStart('.');

                if (time < 10)
                {
                    textMeshPro.color = new Color32(255, 255, 0, 255);

                    if (time < 5)
                    {
                        textMeshPro.color = new Color32(255, 0, 0, 255);
                        if (!flag)
                        {
                            rect.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
                            flag = true;
                        }
                    }
                   
                }
            }
            else
            {
                playerController.failedFlag = true;
                time = 0;
                gameOver.SetActive(true);
            }
        }

    }
}
