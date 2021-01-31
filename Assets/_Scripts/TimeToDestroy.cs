using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}

