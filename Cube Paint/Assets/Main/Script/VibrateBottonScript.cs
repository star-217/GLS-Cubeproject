using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrateBottonScript : MonoBehaviour
{
    private Button testButton;

    private int VibeBotton_swich = 0;

    [SerializeField]private Image image;
    public Sprite[] sprite;

    // Start is called before the first frame update
    void Start()
    {
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(VibeOnclick);
        //image = GetComponent<Image>();
        VibeBotton_swich = PlayerPrefs.GetInt("Vibe");
        PlayerPrefs.SetInt("Vibe", VibeBotton_swich);

        if(VibeBotton_swich == 0)
            image.sprite = sprite[0];
        else if(VibeBotton_swich == 1)
            image.sprite = sprite[1];

    }

    void VibeOnclick()
    {
        if (VibeBotton_swich == 0)
        {
            VibeBotton_swich = 1;
            image.sprite = sprite[1];
        }
        else if(VibeBotton_swich == 1)
        {
            VibeBotton_swich = 0;
            image.sprite = sprite[0];
        }

        PlayerPrefs.SetInt("Vibe", VibeBotton_swich);
    }
}
