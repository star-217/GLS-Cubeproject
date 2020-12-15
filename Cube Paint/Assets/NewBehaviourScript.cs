using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;

    [SerializeField]GameObject hole;
    [SerializeField]Vector3 pos;
    bool flag = false;
    void Start()
    {
        transform = GetComponent<Transform>();
        pos = hole.transform.position;
        pos.y = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
            gameObject.transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.CompareTag("Hole"))
        {
            
           

            transform.DOScale(Vector3.zero, 1.0f);
            flag = true;
        }
    }
}
