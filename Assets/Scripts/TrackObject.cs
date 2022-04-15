using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectToTrack;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - objectToTrack.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToTrack.transform.position + offset;
    }
}
