using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem rain;

    [SerializeField]
    Vector2 secondsToRain;

    [SerializeField]
    Vector2 secondsToWait;

    [Range(0, 1)]
    [SerializeField]
    float rainStartProbability;

    private void Start()
    {
        StartCoroutine(RainCoroutine());
    }

    float GetRandomRainTime()
    {
        return Random.Range(secondsToRain.x, secondsToRain.y);
    }

    float GetRandomWaitTime()
    {
        return Random.Range(secondsToWait.x, secondsToWait.y);
    }

    IEnumerator RainCoroutine()
    {
        float rainStart = Random.Range(0.0f, 1.0f);

        if (rainStart <= rainStartProbability)
        {
            rain.Play();
            yield return new WaitForSeconds(GetRandomRainTime());
        }

        while (true)
        {
            rain.Stop();
            yield return new WaitForSeconds(GetRandomWaitTime());
            rain.Play();
            yield return new WaitForSeconds(GetRandomRainTime());
        }
    }
}
