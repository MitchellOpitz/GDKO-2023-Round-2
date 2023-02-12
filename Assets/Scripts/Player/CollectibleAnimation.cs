using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAnimation : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    private AudioSource audioSource;
    private float H;
    private float S;
    private float V;
    private float trash;
    private ParticleSystem.EmissionModule particles;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.Find("Main Camera");
        audioSource = mainCamera.GetComponent<AudioSource>();
        particles = GameObject.Find("CollectibleParticles").GetComponent<ParticleSystem>().emission;
    }

    public void StartAnimation(AudioClip audioClip, Vector3 startPosition)
    {
        DisablePlayer();
        StartCoroutine(DoAnimation(startPosition));
        StartCoroutine(AfterAnimation(audioClip, 5f));
    }

    private void DisablePlayer()
    {
        //Debug.Log("Disable player.");
        player.GetComponent<Walk>().enabled = false;
        player.GetComponent<Jump>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
    }

    IEnumerator DoAnimation(Vector3 startPosition)
    {
        //Debug.Log("Started Coroutine.");
        float shiftDistance = 3f;
        float animTime = 5f;
        for (float t = 0f; t < animTime; t += Time.deltaTime)
        {
            if (t < (animTime - .75f))
            {
                particles.rateOverTime = (t / animTime) * 1000f;
            } else
            {
                particles.rateOverTime = 0f;
            }
            float newYPosition = startPosition.y + ((t/animTime) * shiftDistance);
            player.transform.position = new Vector3(player.transform.position.x, newYPosition, 0f);
            yield return null;
        }
    }

    IEnumerator AfterAnimation(AudioClip audioClip, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        EnablePlayer();
        GameChanges(audioClip);
    }

    private void EnablePlayer()
    {
        //Debug.Log("Re-enable player.");
        player.GetComponent<Walk>().enabled = true;
        player.GetComponent<Jump>().enabled = true;
    }
    private void GameChanges(AudioClip audioClip)
    {
        //Debug.Log("Updating audio and background.");
        audioSource.clip = audioClip;
        audioSource.Play();
        Color.RGBToHSV(mainCamera.GetComponent<Camera>().backgroundColor, out H, out S, out V);
        mainCamera.GetComponent<Camera>().backgroundColor = Color.HSVToRGB(H, S, V + .03f);
    }
}
