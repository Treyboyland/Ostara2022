using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostDepthRTPC : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.RTPC depthRTPC;

    [SerializeField]
    bool useAbsoluteValue;

    [SerializeField, Range(1, 10)]
    int depthMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        if (depthRTPC == null)
        {
            Debug.LogWarning(this.name + " on gameobject " + gameObject.name + " needs RTPC component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (depthRTPC != null)
        {
            float depth;
            if (transform.position.y > 0)
            {
                depth = 0;
            }
            else
            {
                depth = useAbsoluteValue ? Mathf.Abs(transform.position.y) : transform.position.y;
            }
            depth *= depthMultiplier;
            depthRTPC.SetGlobalValue(depth);
        }
    }
}
