using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    Button testButton;
    // Start is called before the first frame update
    void Start()
    {
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(OnclickScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnclickScene()
    {
        SceneManager.LoadScene("stage2");
    }
}
