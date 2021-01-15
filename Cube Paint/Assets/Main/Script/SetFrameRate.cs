using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{
    [Header("フレームレートの指定")]
    [SerializeField] private int frameRateValue = 60;

    private void Awake()
    {
        Application.targetFrameRate = frameRateValue;
    }
}
