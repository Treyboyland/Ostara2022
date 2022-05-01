using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShrink : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve;

    Vector3 GetLocalScale(float progress)
    {
        return new Vector3(progress, progress, 1);
    }

    public void UpdateTransform(float val)
    {
        transform.localScale = GetLocalScale(curve.Evaluate(val / 100.0f));
    }
}
