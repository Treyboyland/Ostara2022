using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathParticle : MonoBehaviour
{
    [SerializeField]
    Player player;

    public void Spawn()
    {
        transform.position = player.transform.position;
        gameObject.SetActive(true);
    }
}
