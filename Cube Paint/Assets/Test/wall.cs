using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    BoxCollider col;
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > 0)
            col.isTrigger = false;
        else
            col.isTrigger = true;
        
    }
}
