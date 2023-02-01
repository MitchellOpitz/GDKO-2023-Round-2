using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{

    public float cycleTime = 2.0f;
    public float distance = 2.0f;

    private Vector3 startPosition;
    private float timeSinceStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + new Vector3(0f, distance * Mathf.Sin((Mathf.PI * 2) / cycleTime * timeSinceStart), 0f);
        timeSinceStart += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
