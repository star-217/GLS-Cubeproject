using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCubeInBallScript : MonoBehaviour
{
    private ParticleSystem BreakWallParticle;
    private MeshRenderer myMeshRenderer;
    private BoxCollider myBoxCollider;

    [SerializeField] private GameObject subBallobj;

    //見せかけのボールの情報取得
    [SerializeField] private GameObject fakeBall;
    private MeshRenderer fakeBallMeshRenderer;
    private SphereCollider fakeBallSphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        BreakWallParticle = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        myMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        myBoxCollider = gameObject.GetComponent<BoxCollider>();

        //見せかけのボールのあたり判定と存在を消すぜワハハ
        fakeBallMeshRenderer = fakeBall.GetComponent<MeshRenderer>();
        fakeBallSphereCollider = fakeBall.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myMeshRenderer.enabled = false;
            myBoxCollider.enabled = false;
            BreakWallParticle.Play();
            //Destroy(gameObject);

            fakeBallMeshRenderer.enabled = false;
            fakeBallSphereCollider.enabled = false;
            Instantiate(subBallobj, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
        }
    }
}
