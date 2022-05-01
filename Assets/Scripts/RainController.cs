using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField]
    AK.Wwise.Event stormPlayEvent;

    [SerializeField]
    AK.Wwise.Event stormStopEvent;

    public UnityEvent OnRainStarted = new UnityEvent();

    public UnityEvent OnRainStopped = new UnityEvent();

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
            stormPlayEvent.Post(gameObject);
            OnRainStarted.Invoke();
            yield return new WaitForSeconds(GetRandomRainTime());
        }

        while (true)
        {
            rain.Stop();
            stormStopEvent.Post(gameObject);
            OnRainStopped.Invoke();
            yield return new WaitForSeconds(GetRandomWaitTime());
            rain.Play();
            stormPlayEvent.Post(gameObject);
            OnRainStarted.Invoke();
            yield return new WaitForSeconds(GetRandomRainTime());
        }
    }
}
