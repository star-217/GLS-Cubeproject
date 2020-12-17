using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    bool flag;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.CompareTag("Hole"))
        {
            

            transform.DOScale(Vector3.zero, 1.0f);
        }
    }
}
