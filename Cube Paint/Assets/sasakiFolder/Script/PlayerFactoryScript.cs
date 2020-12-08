using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactoryScript : MonoBehaviour
{
    [Header("Player_Blueを入れる")]
    [SerializeField] private GameObject Player_Blue;

    [Header("Player_Redを入れる")]
    [SerializeField] private GameObject Player_Red;

    [Header("Player_Greenを入れる")]
    [SerializeField] private GameObject Player_Green;

    [Header("Player_Yellowを入れる")]
    [SerializeField] private GameObject Player_Yellow;

    [Header("Player_Purpleを入れる")]
    [SerializeField] private GameObject Player_Purple;

    [Header("Player_YellowGreenを入れる")]
    [SerializeField] private GameObject Player_YellowGreen;

    [Header("Player_Blackを入れる")]
    [SerializeField] private GameObject Player_Black;

    [Header("Player_Brownを入れる")]
    [SerializeField] private GameObject Player_Brown;

    [Header("Player_LightBlueを入れる")]
    [SerializeField] private GameObject Player_LightBlue;

    [SerializeField] private GameObject Player_obj;

    private Vector3 player_position;

    private int color_code;

    // Start is called before the first frame update
    void Start()
    {
        Player_obj.SetActive(true);
        if (PlayerPrefs.GetInt("ColorNumber") != 0)
            color_code = PlayerPrefs.GetInt("ColorNumber");
        else
            color_code = 1;
     
        player_position = Player_obj.transform.position;

        if (color_code == 1)
        {
            Instantiate(Player_Blue, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 2)
        {
            Instantiate(Player_Red, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 3)
        {
            Instantiate(Player_Green, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 4)
        {
            Instantiate(Player_Yellow, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 5)
        {
            Instantiate(Player_Purple, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 6)
        {
            Instantiate(Player_YellowGreen, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 7)
        {
            Instantiate(Player_Black, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 8)
        {
            Instantiate(Player_Brown, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        if (color_code == 9)
        {
            Instantiate(Player_LightBlue, new Vector3(player_position.x, player_position.y, player_position.z), Quaternion.identity);
        }

        Player_obj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
