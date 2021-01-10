using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private Button testButton;
    
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
        PlayerPrefs.SetInt("Player", 1);
        int stage = PlayerPrefs.GetInt("stage");
        SceneManager.LoadScene("MainStage" +stage);
    }
}
