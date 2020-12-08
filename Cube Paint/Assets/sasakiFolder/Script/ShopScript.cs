using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ShopScript : MonoBehaviour
{
    private Button testButton;

    // Start is called before the first frame update
    void Start()
    {
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(ShopOnclick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ShopOnclick()
    {
        Debug.Log("ボタンが押されたよ");
        SceneManager.LoadScene("ShopScene");
    }
}
