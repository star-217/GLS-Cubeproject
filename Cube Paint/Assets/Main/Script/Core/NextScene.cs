using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    Button testButton;
    public static int stage = 1;
    //public int Stage
    //{
    //    get { return stage; }
       
    //}

    // Start is called before the first frame update
    void Start()
    {
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(OnclickScene);
        PlayerPrefs.SetInt("stage", stage);
        //stage = PlayerPrefs.GetInt("stage", stage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnclickScene()
    {
      
        stage += 1;
        if (stage > 5)
        {
            stage = 1;
        }

        SceneManager.LoadScene("stage"+ stage);
    }
}
