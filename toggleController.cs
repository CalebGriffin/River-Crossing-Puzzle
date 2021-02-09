using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleController : MonoBehaviour
{
    // Creates a variable to control the toggle
    public Text ttsButton;

    void FixedUpdate()
    {
        // Sets the toggle to match the state of the Text-to-speech object
        if (gPos.tts == true)
        {
            ttsButton.text = "On";
        }
        else if (gPos.tts == false)
        {
            ttsButton.text = "Off";
        }
    }
}
