using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{
    // Creates a game object to store the text to speech
    public GameObject tts;

    // Awake runs on the first frame of the game
    public void Awake()
    {
        // Checks if the Text-to-speech game object should be active and then activates it if it should be
        if (gPos.tts == true)
        {
            tts.SetActive(true);
        }
        else if (gPos.tts == false)
        {
            tts.SetActive(false);
        }
    }

    // Loads the Rules scene
    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    // Loads the Controls scene
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    // Loads the Menu scene
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Loads the Game scene
    public void Game()
    {
        SceneManager.LoadScene("Main");
    }

    // Enables easy mode
    public void EasyModeEnabled()
    {
        gPos.easyMode = true;
    }

    // Disables easy mode
    public void EasyModeDisabled()
    {
        gPos.easyMode = false;
    }

    // Sets the Text-to-speech object to either enabled or disabled
    public void ToggleTTS()
    {
        if (gPos.tts == true)
        {
            gPos.tts = false;
            tts.SetActive(false);
        }
        else if (gPos.tts == false)
        {
            gPos.tts = true;
            tts.SetActive(true);
        }
    }
}
