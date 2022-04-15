using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterParticlePlay : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        while (particle.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
