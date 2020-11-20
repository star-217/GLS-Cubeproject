using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakusuryouikiCheckScript : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 localScale;
    //public Texture texture;

    // Start is called before the first frame update
    void Start()
    {
        // transformを取得
        myTransform = this.transform;
        // ローカル座標を基準にした、サイズを取得
        localScale = myTransform.localScale;
        Debug.Log("kakusuryouiki : localScale.x" + localScale.x);
        Debug.Log("kakusuryouiki : localScale.z" + localScale.z);
        //Debug.Log("kakusuryouiki texture Size : " + texture.width + " by " + texture.height);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
