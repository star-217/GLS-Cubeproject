using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve_Move : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 relayPos;
    private Vector2 targetPos;

    private float time = 0.0f;
    private float random_relayPosX;
    private float random_relayPosY;

    private float random_time;

    // Start is called before the first frame update
    void Start()
    {
        random_relayPosX = 0.0f;
        random_relayPosY = 0.0f;

        random_time = Random.Range(1.0f,2.0f);

        startPos = GetComponent<RectTransform>().position;

        random_relayPosX = Random.Range(startPos.x - 200, startPos.x + 200);
        random_relayPosY = Random.Range(startPos.y, startPos.x + 200);

        relayPos = new Vector2(random_relayPosX, random_relayPosY);

        targetPos = GameObject.FindGameObjectWithTag("GetDiamondTag").GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        //弾の進行具合（Lerpの第三引数に入れる）
        time += Time.deltaTime;
        //二次ベジェ曲線を使う
        //スタートから中継地点をつなぐベクトル上を走る点の位置
        var firstVec = Vector3.Lerp(startPos, relayPos, time * random_time);
        //中継地点からターゲットまでをつなぐベクトル上を走る点の位置
        var SecondVec = Vector3.Lerp(relayPos, targetPos, time * random_time);
        //上の二点をつなぐベクトル上を走る点（弾）の位置
        var vec = Vector3.Lerp(firstVec, SecondVec, time * random_time);
        //弾の位置を代入する
        this.transform.position = vec;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "GetDiamondTag")
        {
            if (PlayerPrefs.GetInt("Vibe") == 1)
                Vibration.Vibrate(50);

            Destroy(this.gameObject);
        }
    }
}
