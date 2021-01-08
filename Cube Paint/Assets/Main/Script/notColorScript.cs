using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

public class notColorScript : MonoBehaviour
{
    [SerializeField] private GameObject subPlayer_obj;
    [SerializeField] private GameObject Player_obj;
    private Painter painter;
    private PlayerPainter playerPainter;

    private void Start()
    {
        painter = subPlayer_obj.GetComponent<Painter>();
        playerPainter = Player_obj.GetComponent<PlayerPainter>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player"/*notdoublePaintTag*/)
        {
            if (painter != null)
                painter.enabled = false;
            
            if(playerPainter != null)
                playerPainter.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player"/*notdoublePaintTag*/)
        {
            if (painter != null)
                painter.enabled = true;
            
            if (playerPainter != null)
                playerPainter.enabled = true;
            
        }
    }
}
