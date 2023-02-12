using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text tmp;
    public float fadeTime;

    public void StartDialogue(Dialogue dialogue)
    {
        tmp.color = new Color(1f, 1f, 1f, 1f);
        tmp.text = dialogue.text;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        float textAlpha = 1f;

        for (float t = 0f; t < 1f; t += Time.deltaTime / fadeTime)
        {
            textAlpha = (Mathf.Lerp(1, 0f, t));
            tmp.color = new Color(1f, 1f, 1f, textAlpha);
            yield return null;
        }

        textAlpha = 0f;
    }
}