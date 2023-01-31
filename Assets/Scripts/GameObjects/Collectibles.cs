using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    public GameObject nextCollectible;
    public string colorUnlocked;

    private Vector3 startingPosition;
    private Vector3 tempPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPosition = startingPosition;
        tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {            
            //FindObjectOfType<AudioManager>().PlaySound("Temp Collectible");
            nextCollectible.SetActive(true);
            ColorUnlock();
            Destroy(gameObject);
        }
    }

    private void ColorUnlock()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(colorUnlocked);
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Activation>().Activate();
        }
    }
}
