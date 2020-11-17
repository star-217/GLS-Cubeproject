using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
     public Button testButton;
    [SerializeField] private int stage = 1;

    //public int Stage
    //{
    //    get { return stage; }
    //    set { stage = value; }
    //}

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
        stage += 1;
        SceneManager.LoadScene("stage"+ stage);
    }
}
