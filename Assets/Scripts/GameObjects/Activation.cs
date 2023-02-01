using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public Color purple = new Color((float)224 / 255, 0, (float)225 / 255, (float)255 / 255);
    public Color blue = new Color(0, (float)133 / 255, (float)255 / 255, (float)255 / 255);
    public Color green = new Color(0, (float)255 / 255, (float)38 / 255, (float)255 / 255);
    public Color yellow = new Color((float)255 / 255, (float)238 / 255, 0, (float)255 / 255);
    public Color orange = new Color((float)255 / 255, (float)108 / 255, 0, (float)255 / 255);
    public Color red = new Color((float)255 / 255, 0, 0, (float)255 / 255);
    public Color pink = new Color((float)255 / 255, 0, (float)164 / 255, (float)255 / 255);

    public Color thisColor;

    public void Activate(string colorUnlocked)
    {
        this.GetComponent<SpriteRenderer>().color = thisColor;

        if (colorUnlocked == "Green")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
