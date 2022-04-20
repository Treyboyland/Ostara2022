using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Game/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [Tooltip("Seconds it takes for the player to dig a block")]
    [SerializeField]
    float digTime;

    /// <summary>
    /// Seconds it takes for the player to dig a block
    /// </summary>
    /// <value></value>
    public float DigTime { get { return digTime; } }

    [Tooltip("How fast the player moves")]
    [SerializeField]
    float speed;

    /// <summary>
    /// How fast the player moves
    /// </summary>
    /// <value></value>
    public float Speed { get { return speed; } set { speed = value; } }

    [Tooltip("Size of box collider on player")]
    [SerializeField]
    Vector2 colliderSize;

    public Vector2 ColliderSize { get { return colliderSize; } }

    [Tooltip("Animations for the player")]
    [SerializeField]
    RuntimeAnimatorController playerAnimator;

    /// <summary>
    /// Animations for the player
    /// </summary>
    /// <value></value>
    public RuntimeAnimatorController PlayerAnimator { get { return playerAnimator; } }
}
