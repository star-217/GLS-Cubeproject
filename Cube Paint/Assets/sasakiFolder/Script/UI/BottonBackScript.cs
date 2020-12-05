using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BottonBackScript : MonoBehaviour
{
    Button testButton;

    // Start is called before the first frame update
    void Start()
    {
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(Onclick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Onclick()
    {
        // イベントに登録
        //SceneManager.sceneLoaded += GameSceneLoaded;

        SceneManager.LoadScene("LoadScene");
    }

    //private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    //{
    //    // シーン切り替え後のスクリプトを取得
    //    var gameManager = GameObject.FindWithTag("").GetComponent<MiddleForgivenessScript>();

    //    // データを渡す処理
    //   //gameManager.Clor;

    //    // イベントから削除
    //    SceneManager.sceneLoaded -= GameSceneLoaded;
    //}
}
