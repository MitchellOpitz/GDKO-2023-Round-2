using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    public GameObject nextCollectible;
    public string colorUnlocked;
    public AudioClip audioTrack;
    public float Sshift = .1f;
    public float Vshift = .1f;
    public bool isPurple;

    private Vector3 startingPosition;
    private Vector3 tempPosition;
    private GameObject mainCamera;
    private AudioSource audioSource;
    private Color myColor;
    private float H;
    private float S;
    private float V;
    private float trash;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        mainCamera = GameObject.Find("Main Camera");
        audioSource = mainCamera.GetComponent<AudioSource>();
        myColor = GetComponent<SpriteRenderer>().color;
        Color.RGBToHSV(myColor, out H, out S, out V);
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
            audioSource.Stop();
            audioSource.clip = audioTrack;
            audioSource.Play();
            if (isPurple)
            {
                Color.RGBToHSV(mainCamera.GetComponent<Camera>().backgroundColor, out trash, out trash, out V);
            } else
            {
                Color.RGBToHSV(mainCamera.GetComponent<Camera>().backgroundColor, out trash, out S, out V);
            }
            mainCamera.GetComponent<Camera>().backgroundColor = Color.HSVToRGB(H, S - Sshift, V + Vshift);
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
            obstacle.GetComponent<Activation>().Activate(colorUnlocked);
        }
    }
}
