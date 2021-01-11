using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    [SerializeField] public float crea_time = 0; // クリアするための時間
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        crea_time -= Time.deltaTime;
        textMeshPro.text = "" + (int)crea_time;
    }
}
