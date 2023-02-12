using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public string dialogueText;
    public bool lastOne;

    private Dialogue dialogue;

    private void Start()
    {
        dialogue = new Dialogue(dialogueText);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Destroy(gameObject);
        }
    }

    public void WaitTimer()
    {
        StartCoroutine(LastDialogueBox());
    }

    IEnumerator LastDialogueBox()
    {
        yield return new WaitForSeconds(20f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
