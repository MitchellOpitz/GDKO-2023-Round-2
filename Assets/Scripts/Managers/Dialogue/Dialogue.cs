using UnityEngine;

public class Dialogue
{

    public string text;

    public Dialogue(string text)
    {
        this.text = text;
        Debug.Log("Text set to: " + text);
    }
}