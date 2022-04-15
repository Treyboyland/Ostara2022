using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField]
    Vector2 rayCastDirection;

    [SerializeField]
    float distance;

    [SerializeField]
    LayerMask mask;

    RaycastHit2D hit;

    public RaycastHit2D Hit { get { return hit; } }

    public bool WasHit
    {
        get
        {
            return hit.collider != null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, rayCastDirection, distance, mask.value);
    }
}
