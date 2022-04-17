using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityModifier : MonoBehaviour
{
    [SerializeField]
    float maxHeight;

    [SerializeField]
    float gravity;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    bool turnOnGravity;

    public bool TurnOnGravity { get { return turnOnGravity; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (turnOnGravity)
        {
            body.gravityScale = transform.position.y > maxHeight ? gravity : 0;
        }
    }
}
