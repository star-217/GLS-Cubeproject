using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    int time = 0;
    int stage = 1;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += LoadScene;
        //StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        //stage = LoadStage.stage;
        time++;

        if(time >= 3)
        {
            SceneManager.LoadScene("Stage" + stage);
        }

       
    }

    void LoadScene(Scene scene,LoadSceneMode loadSceneMode)
    {

    }



    IEnumerator Test()
    {
        //ここに処理を書く

        //1フレーム停止
        var async = SceneManager.LoadSceneAsync("Stage" + stage);

        yield return async;
        //yield return null;

        //ここに再開後の処理を書く
    }

}
