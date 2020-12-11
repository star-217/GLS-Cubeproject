using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class AsyncCapture : MonoBehaviour
{
    Queue<AsyncGPUReadbackRequest> _requests = new Queue<AsyncGPUReadbackRequest>();

    static Texture2D _tex;
    static RenderTexture _renderTex;

    void Update()
    {
        while (_requests.Count > 0)
        {
            var req = _requests.Peek();

            if (req.hasError)
            {
                Debug.Log("GPU readback error detected.");
                _requests.Dequeue();
            }
            else if (req.done)
            {
                Unity.Collections.NativeArray<Color32> buffer = req.GetData<Color32>();
                _tex.LoadRawTextureData(buffer);
                _tex.Apply();
                _requests.Dequeue();
            }
            else
            {
                break;
            }
        }
    }

    private void Start()
    {
        _tex = new Texture2D(Screen.currentResolution.width, Screen.currentResolution.height, TextureFormat.RGBA32, false);
        _renderTex = new RenderTexture(_tex.width, _tex.height, 24, RenderTextureFormat.ARGB32);

    }


    private void OnPostRender()
    {
        Graphics.Blit(null, _renderTex);
        if (_requests.Count < 8)
        {
            _requests.Enqueue(AsyncGPUReadback.Request(_renderTex));
        }
        else
            Debug.Log("Too many requests.");
    }


}
