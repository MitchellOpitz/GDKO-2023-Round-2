using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openTime;
    public float openDistance;

    private Vector3 startPosition;
    private float timeSinceStart;
    private bool opening = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (opening && timeSinceStart < openTime)
        {
            transform.position = startPosition + new Vector3(0f, openDistance / openTime * timeSinceStart, 0f);
            timeSinceStart += Time.deltaTime;
        } else
        {
            opening = false;
        }
    }

    public void OpenDoor()
    {
        opening = true;
    }
}
