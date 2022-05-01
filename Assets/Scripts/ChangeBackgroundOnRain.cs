using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundOnRain : MonoBehaviour
{
    [SerializeField]
    RainController controller;

    [SerializeField]
    Color normalColor;

    [SerializeField]
    Color rainColor;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    float secondsToTransition;

    private void Awake()
    {
        controller.OnRainStarted.AddListener(() =>
        {
            StopAllCoroutines();
            StartCoroutine(ColorChange(normalColor, rainColor));
        });

        controller.OnRainStopped.AddListener(() =>
        {
            StopAllCoroutines();
            StartCoroutine(ColorChange(rainColor, normalColor));
        });
    }

    IEnumerator ColorChange(Color start, Color end)
    {
        float elapsed = 0;

        while (elapsed < secondsToTransition)
        {
            elapsed += Time.deltaTime;
            mainCamera.backgroundColor = Color.Lerp(start, end, elapsed / secondsToTransition);
            yield return null;
        }

        mainCamera.backgroundColor = end;
    }

}
