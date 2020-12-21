using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    [SerializeField]GameObject hole;
    Vector3 Pos;
    bool flag = false;
    void Start()
    {
        transform = GetComponent<Transform>();
        Pos = hole.transform.position;
        Pos.y = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (flag)
        {
            gameObject.transform.position = Pos;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
       

        if(other.gameObject.CompareTag("Hole"))
        {
            

            transform.DOScale(Vector3.zero, 0.7f);
            flag = true;
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
