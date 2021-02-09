using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gPos
{
    // Sets the positions for each of the different elements in the game
    // They are set to public and static so that the can be accessed by the game manager script
    public static Vector3 dinoStart = new Vector3(-6.85f, 1, 0);
    public static Vector3 dinoBoatStart = new Vector3(-6.85f, -2.42f, 0);
    public static Vector3 dinoBoatEnd = new Vector3(3.1f, -2.42f, 0);
    public static Vector3 dinoEnd = new Vector3(3.1f, 1, 0);

    public static Vector3 cowStart = new Vector3(-5.6f, 1, 0);
    public static Vector3 cowBoatStart = new Vector3(-5.6f, -2.42f, 0);
    public static Vector3 cowBoatEnd = new Vector3(4.35f, -2.42f, 0);
    public static Vector3 cowEnd = new Vector3(4.35f, 1, 0);

    public static Vector3 duckStart = new Vector3(-4.35f, 1, 0);
    public static Vector3 duckBoatStart = new Vector3(-4.35f, -2.42f, 0);
    public static Vector3 duckBoatEnd = new Vector3(5.6f, -2.42f, 0);
    public static Vector3 duckEnd = new Vector3(5.6f, 1, 0);

    public static Vector3 beansStart = new Vector3(-3.1f, 1, 0);
    public static Vector3 beansBoatStart = new Vector3(-3.1f, -2.42f, 0);
    public static Vector3 beansBoatEnd = new Vector3(6.85f, -2.42f, 0);
    public static Vector3 beansEnd = new Vector3(6.85f, 1, 0);

    public static Vector3 boatStart = new Vector3(-5, -2, 0);
    public static Vector3 boatEnd = new Vector3(5, -2, 0);

    public static Vector3 waterStart = new Vector3(-8, -5.2f, 0);
    public static Vector3 waterEnd = new Vector3(-20, -5.2f, 0);

    // Sets a string variable to control easy mode
    public static bool easyMode;

    // Creates a boolean variable to control the text to speech
    public static bool tts = false;

    // Creates a string to confirm the user's choice in easy mode
    public static string confirmed = "null";
}
