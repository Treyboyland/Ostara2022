using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "Game/Game Constants")]
public class GameConstantsSO : ScriptableObject
{
    /// <summary>
    /// Distance bunny will jump, or blocks should be placed
    /// </summary>
    [Tooltip("Distance bunny will jump, or blocks should be placed")]
    [SerializeField]
    float unitDistance;

    /// <summary>
    /// Distance bunny will jump, or blocks should be placed
    /// </summary>
    public float UnitDistance { get { return unitDistance; } }
}
