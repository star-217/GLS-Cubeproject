using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class LoginScore : MonoBehaviour
{
    Button testButton;
    float score;
    public float score_up = 500;
    [SerializeField] GameObject Login;
    RectTransform rect;


    [SerializeField] private GameObject crystal_ui;     //ログボタップしたときに散らばるクリスタル
    [SerializeField] private GameObject getBotton;      //ログボをゲットするときに押すボタン

    private RectTransform getBotton_RectTransform;
    private Vector3 getBotton_pos;
    private GameObject obj;                             //ただのオブジェクト。
    private float random_GetBotton_posX;
    private float random_GetBotton_posY;
    private GameObject safeArea;


    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("score_save");
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(OnClickBonus);
        rect = GetComponent<RectTransform>();

        rect.DOScale(1.3f, 0.5f).SetLoops(-1,LoopType.Yoyo);

        getBotton_RectTransform = getBotton.GetComponent<RectTransform>();
        getBotton_pos = getBotton_RectTransform.position;

        safeArea = GameObject.Find("SafeArea");

        random_GetBotton_posX = 0.0f;
        random_GetBotton_posY = 0.0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnClickBonus()
    {
        for(int i = 0;i < 5; i++)
        {
            random_GetBotton_posX = Random.Range(getBotton_pos.x - 200, getBotton_pos.x + 200);
            random_GetBotton_posY = Random.Range(getBotton_pos.y - 200, getBotton_pos.y + 200);
            obj = Instantiate(crystal_ui, new Vector3(random_GetBotton_posX, random_GetBotton_posY, getBotton_pos.z),Quaternion.identity);
            obj.transform.parent = safeArea.transform;
        }

        Invoke("PlayerStop", 0.2f);
        if (Login != null)
            Login.SetActive(false);
    }

    void PlayerStop()
    {
         PlayerPrefs.SetInt("Player", 1);
    }

  
}
