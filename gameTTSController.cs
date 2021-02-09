using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTTSController : MonoBehaviour
{
    // Creates game object variables to control the different objects
    public GameObject dinoTTS;
    public GameObject cowTTS;
    public GameObject duckTTS;
    public GameObject beansTTS;
    public GameObject boatTTS;

    // If Text-to-speech is enabled when the user hovers over an object, the code will read out it's name
    public void MainTTS(string inputStr)
    {
        switch (inputStr)
        {
            case "dino":
                StartCoroutine("Dino");
                break;
            
            case "cow":
                StartCoroutine("Cow");
                break;
            
            case "duck":
                StartCoroutine("Duck");
                break;
            
            case "beans":
                StartCoroutine("Beans");
                break;
            
            case "boat":
                StartCoroutine("Boat");
                break;
        }
    }
 
    IEnumerator Dino()
    {
        dinoTTS.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        dinoTTS.SetActive(false);
    }

    IEnumerator Cow()
    {
        cowTTS.SetActive(true);
        yield return new WaitForSeconds(1);
        cowTTS.SetActive(false);
    }

    IEnumerator Duck()
    {
        duckTTS.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        duckTTS.SetActive(false);
    }

    IEnumerator Beans()
    {
        beansTTS.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        beansTTS.SetActive(false);
    }

    IEnumerator Boat()
    {
        boatTTS.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        boatTTS.SetActive(false);
    }
}
