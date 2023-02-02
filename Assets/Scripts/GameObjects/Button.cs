using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Door door;
    public GameObject wire;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled && collision.gameObject.CompareTag("Player"))
        {
            door.OpenDoor();
            Destroy(wire);
            Destroy(gameObject);
        }
    }
}
