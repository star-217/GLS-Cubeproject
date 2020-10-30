using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
 

      // 変数
      int frameCount;
      float prevTime;
      float fps;
    public Text text;

    // 初期化処理
    void Start()
      {
        Application.targetFrameRate = 60;
        // 変数の初期化
        frameCount = 0;
          prevTime = 0.0f;
      }

      // 更新処理
      void Update()
      {
          frameCount++;
          float time = Time.realtimeSinceStartup - prevTime;

          if (time >= 0.5f)
          {
              fps = frameCount / time;
             // Debug.Log(fps);

              frameCount = 0;
              prevTime = Time.realtimeSinceStartup;
          }

        text.text = ""+(int)fps;
      }

    // 表示処理
   
    

}
