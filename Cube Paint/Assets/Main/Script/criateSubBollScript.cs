using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criateSubBollScript : MonoBehaviour
{
    public GameObject originObject; //オリジナルのオブジェクト

    [Header("サブボール出現用のオブジェクト入れる")]
    [SerializeField]private GameObject createObj;
    private Vector3 myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = createObj.GetComponent<Transform>().localPosition;
        Instantiate(originObject, new Vector3(myTransform.x, myTransform.y, myTransform.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
