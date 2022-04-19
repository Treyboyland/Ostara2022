using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainTrigger : MonoBehaviour
{
    [SerializeField]
    ParticleSystem rain;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = rain.GetCollisionEvents(other, collisionEvents);

        //Debug.LogWarning("Particles hit this frame: " + numCollisionEvents);
    }
}
