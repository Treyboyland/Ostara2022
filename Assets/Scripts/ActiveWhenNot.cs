using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWhenNot : MonoBehaviour
{
    [Tooltip("Controlled by this script")]
    [SerializeField]
    GameObject toControl;

    [SerializeField]
    [Tooltip("Checked against")]
    GameObject toCheck;

    // Update is called once per frame
    void Update()
    {
        toControl.SetActive(!toCheck.activeInHierarchy);
    }
}
