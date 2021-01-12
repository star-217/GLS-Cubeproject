using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public float maxTime = 10;
    public float time = 0; // クリアするための時間
    float seconds;
    private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.clearFlag == false)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;


                textMeshPro.text = "Time:" + time.ToString("00"); //+ ":" + (time-(int)time).ToString(".00").TrimStart('0').TrimStart('.');
            }
            else
            {

                time = 0;
                gameOver.SetActive(true);
            }
        }

    }
}
