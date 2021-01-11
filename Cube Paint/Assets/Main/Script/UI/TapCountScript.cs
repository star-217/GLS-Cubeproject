using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TapCountScript : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        playerController = player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "" + playerController.tapCount;
    }
}
