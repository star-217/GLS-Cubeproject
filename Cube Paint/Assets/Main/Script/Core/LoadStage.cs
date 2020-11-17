using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour
{
    static public int stage = 1;

    // Start is called before the first frame update
    void Start()
    {

        stage = PlayerPrefs.GetInt("stage");
        if (PlayerPrefs.GetInt("stage") == 0)
            stage = 1;
        SceneManager.LoadScene(stage);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
}
