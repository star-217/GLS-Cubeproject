using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAnimation_Scattered : MonoBehaviour
{
    [SerializeField] private GameObject crystal_ui;     //ログボタップしたときに散らばるクリスタル
    [SerializeField] private GameObject getBotton;      //ログボをゲットするときに押すボタン

    private RectTransform getBotton_RectTransform;
    private Vector3 getBotton_pos;
    // Start is called before the first frame update
    void Start()
    {
        getBotton_RectTransform = getBotton.GetComponent<RectTransform>();
        getBotton_pos = getBotton_RectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
