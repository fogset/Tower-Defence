using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    bool isPlaceable;

    void OnMouseDown()
    {
        if (isPlaceable == true)
        {
            Debug.Log(transform.name);
        }
    }
}
