using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Creates lists to keep track of where each object is
    List<string> startList = new List<string>();
    List<string> boatList = new List<string>();
    List<string> endList = new List<string>();

    // Creates game object variables for all of the elements in the game
    public GameObject dino;
    public GameObject cow;
    public GameObject duck;
    public GameObject beans;
    public GameObject boat;

    // Creates game object variables for the canvases
    public GameObject winCanvas;
    public GameObject failCanvas;
    public GameObject confirmCanvas;

    // Creates game object variables for the text to speech objects
    public GameObject failTTS;
    public GameObject confirmTTS;
    public GameObject winTTS;

    // Creates boolean variables to check if the player has failed or won
    public bool failed = false;
    public bool won = false;

    // Creates an integer variable to store how many moves the player has made
    public int moves;

    // Creates a game object variable to control the text
    public Text moveLabel;

    // Lists puts all of the objects into the starting list
    public void Lists()
    {
        startList.Add("dino");
        startList.Add("cow");
        startList.Add("duck");
        startList.Add("beans");
    }

    // Creates boolean variables to control when the objects move
    public bool dinoStartMove;
    public bool cowStartMove;
    public bool duckStartMove;
    public bool beansStartMove;
    public bool boatStartMove;

    public bool dinoEndMove;
    public bool cowEndMove;
    public bool duckEndMove;
    public bool beansEndMove;
    public bool boatEndMove;

    // Creates a float to control the speed
    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the position elements of each game object to their starting positions
        // The starting positions are defined in the gPos class
        dino.transform.position = gPos.dinoStart;
        cow.transform.position = gPos.cowStart;
        duck.transform.position = gPos.duckStart;
        beans.transform.position = gPos.beansStart;
        boat.transform.position = gPos.boatStart;

        // Runs the lists method to put the elements into the right lists
        Lists();

        // Makes the canvases invisible so that the player can see the puzzle
        winCanvas.SetActive(false);
        failCanvas.SetActive(false);
        confirmCanvas.SetActive(false);

        // Makes the Text-to-speech objects invisible so that they are not triggered by accident
        failTTS.SetActive(false);
        confirmTTS.SetActive(false);
        winTTS.SetActive(false);
    }

    // Update runs every frame
    void Update()
    {
        // Updates the step based on how well the game is running
        float step = speed * Time.deltaTime;

        // Moves the objects to the end bank in the boat
        if (dinoStartMove == true)
        {
            dino.transform.position = Vector3.MoveTowards(dino.transform.position, gPos.dinoBoatEnd, step);
            if (dino.transform.position == gPos.dinoBoatEnd)
            {
                dinoStartMove = false;
            }
        }
        if (cowStartMove == true)
        {
            cow.transform.position = Vector3.MoveTowards(cow.transform.position, gPos.cowBoatEnd, step);
            if (cow.transform.position == gPos.cowBoatEnd)
            {
                cowStartMove = false;
            }
        }
        if (duckStartMove == true)
        {
            duck.transform.position = Vector3.MoveTowards(duck.transform.position, gPos.duckBoatEnd, step);
            if (duck.transform.position == gPos.duckBoatEnd)
            {
                duckStartMove = false;
            }
        }
        if (beansStartMove == true)
        {
            beans.transform.position = Vector3.MoveTowards(beans.transform.position, gPos.beansBoatEnd, step);
            if (beans.transform.position == gPos.beansBoatEnd)
            {
                beansStartMove = false;
            }
        }
        if (boatStartMove == true)
        {
            boat.transform.position = Vector3.MoveTowards(boat.transform.position, gPos.boatEnd, step);
            if (boat.transform.position == gPos.boatEnd)
            {
                boatStartMove = false;
            }
        }

        // Moves the objects to the start bank in the boat
        if (dinoEndMove == true)
        {
            dino.transform.position = Vector3.MoveTowards(dino.transform.position, gPos.dinoBoatStart, step);
            if (dino.transform.position == gPos.dinoBoatStart)
            {
                dinoEndMove = false;
            }
        }
        if (cowEndMove == true)
        {
            cow.transform.position = Vector3.MoveTowards(cow.transform.position, gPos.cowBoatStart, step);
            if (cow.transform.position == gPos.cowBoatStart)
            {
                cowEndMove = false;
            }
        }
        if (duckEndMove == true)
        {
            duck.transform.position = Vector3.MoveTowards(duck.transform.position, gPos.duckBoatStart, step);
            if (duck.transform.position == gPos.duckBoatStart)
            {
                duckEndMove = false;
            }
        }
        if (beansEndMove == true)
        {
            beans.transform.position = Vector3.MoveTowards(beans.transform.position, gPos.beansBoatStart, step);
            if (beans.transform.position == gPos.beansBoatStart)
            {
                beansEndMove = false;
            }
        }
        if (boatEndMove == true)
        {
            boat.transform.position = Vector3.MoveTowards(boat.transform.position, gPos.boatStart, step);
            if (boat.transform.position == gPos.boatStart)
            {
                boatEndMove = false;
            }
        }
    }

    // OnClick is called by any button and it takes the input of the button as a string
    public void OnClick(string btnString)
    {
        switch(btnString)
        {
            // Checks where the object is and then moves it accordingly
            // Update the list that keep track of where the objects are
            // If the object is moved to the end, it will check if the player has won
            case "dino":
               if (dino.transform.position == gPos.dinoStart && boat.transform.position == gPos.boatStart)
               {
                   dino.transform.position = gPos.dinoBoatStart;

                   startList.Remove(btnString);
                   boatList.Add(btnString);
               }
               else if (dino.transform.position == gPos.dinoEnd && boat.transform.position == gPos.boatEnd)
               {
                   dino.transform.position = gPos.dinoBoatEnd;

                   endList.Remove(btnString);
                   boatList.Add(btnString);
               }
               else if (dino.transform.position == gPos.dinoBoatStart)
               {
                   dino.transform.position = gPos.dinoStart;

                   boatList.Remove(btnString);
                   startList.Add(btnString);
               }
               else if (dino.transform.position == gPos.dinoBoatEnd)
               {
                   dino.transform.position = gPos.dinoEnd;

                   boatList.Remove(btnString);
                   endList.Add(btnString);

                   won = WinCheck();
                   if (won == true)
                   {
                       winCanvas.SetActive(true);
                       if (gPos.tts == true)
                       {
                           winTTS.SetActive(true);
                       }
                   }
               }
               break;
            
            case "cow":
                if (cow.transform.position == gPos.cowStart && boat.transform.position == gPos.boatStart)
                {
                    cow.transform.position = gPos.cowBoatStart;

                    startList.Remove(btnString);
                    boatList.Add(btnString);
                }
                else if (cow.transform.position == gPos.cowEnd && boat.transform.position == gPos.boatEnd)
                {
                    cow.transform.position = gPos.cowBoatEnd;

                    endList.Remove(btnString);
                    boatList.Add(btnString);
                }
                else if (cow.transform.position == gPos.cowBoatStart)
                {
                    cow.transform.position = gPos.cowStart;

                    boatList.Remove(btnString);
                    startList.Add(btnString);
                }
                else if (cow.transform.position == gPos.cowBoatEnd)
                {
                    cow.transform.position = gPos.cowEnd;

                    boatList.Remove(btnString);
                    endList.Add(btnString);

                    won = WinCheck();
                    if (won == true)
                    {
                        winCanvas.SetActive(true);
                        if (gPos.tts == true)
                        {
                            winTTS.SetActive(true);
                        }
                    }
                }
                break;
            
            case "duck":
                if (duck.transform.position == gPos.duckStart && boat.transform.position == gPos.boatStart)
                {
                    duck.transform.position = gPos.duckBoatStart;

                    startList.Remove(btnString);
                    boatList.Add(btnString);
                }
                else if (duck.transform.position == gPos.duckEnd && boat.transform.position == gPos.boatEnd)
                {
                    duck.transform.position = gPos.duckBoatEnd;

                    endList.Remove(btnString);
                    boatList.Add(btnString);
                }
                else if (duck.transform.position == gPos.duckBoatStart)
                {
                    duck.transform.position = gPos.duckStart;

                    boatList.Remove(btnString);
                    startList.Add(btnString);
                }
                else if (duck.transform.position == gPos.duckBoatEnd)
                {
                    duck.transform.position = gPos.duckEnd;

                    boatList.Remove(btnString);
                    endList.Add(btnString);

                    won = WinCheck();
                    if (won == true)
                    {
                        winCanvas.SetActive(true);
                        if (gPos.tts == true)
                        {
                            winTTS.SetActive(true);
                        }
                    }
                }
                break;
            
            case "beans":
                if (beans.transform.position == gPos.beansStart && boat.transform.position == gPos.boatStart)
                {
                    beans.transform.position = gPos.beansBoatStart;

                    startList.Remove(btnString);
                    boatList.Add(btnString);
                }
                else if (beans.transform.position == gPos.beansEnd && boat.transform.position == gPos.boatEnd)
                {
                    beans.transform.position = gPos.beansBoatEnd;

                    endList.Remove(btnString);
                    boatList.Add(btnString);
                }
                else if (beans.transform.position == gPos.beansBoatStart)
                {
                    beans.transform.position = gPos.beansStart;

                    boatList.Remove(btnString);
                    startList.Add(btnString);
                }
                else if (beans.transform.position == gPos.beansBoatEnd)
                {
                    beans.transform.position = gPos.beansEnd;

                    boatList.Remove(btnString);
                    endList.Add(btnString);

                    won = WinCheck();
                    if (won == true)
                    {
                        winCanvas.SetActive(true);
                        if (gPos.tts == true)
                        {
                            winTTS.SetActive(true);
                        }
                    }
                }
                break;
            
            case "boat":
                if (boatList.Count <= 2 && boatList.Count > 0)
                {
                    if (gPos.easyMode == true)
                    {
                        if (boat.transform.position == gPos.boatStart)
                        {
                            failed = FailCheck("start");
                            if (failed == true)
                            {
                                // Shows a pop up that will ask the user if they want to make that move
                                confirmCanvas.SetActive(true);
                                if (gPos.tts == true)
                                {
                                    confirmTTS.SetActive(true);
                                }
                                StartCoroutine("StartWaitUntil");
                            }
                            else
                            {
                                // Increases the number of moves and changes the text to show the number of moves
                                moves = moves + 1;
                                moveLabel.text = moves.ToString();

                                // Changes the boat's position
                                boatStartMove = true;

                                // For each animal that is in the boat it will check which animal it is and then move it
                                foreach  (string element in boatList)
                                {
                                    if (element == "dino")
                                    {
                                        dinoStartMove = true;
                                    }
                                    else if (element == "cow")
                                    {
                                        cowStartMove = true;
                                    }
                                    else if (element == "duck")
                                    {
                                        duckStartMove = true;
                                    }
                                    else if (element == "beans")
                                    {
                                        beansStartMove = true;
                                    }
                                }
                        
                                failed = FailCheck("start");
                                if (failed == true)
                                {
                                    failCanvas.SetActive(true);
                                    if (gPos.tts == true)
                                    {
                                        failTTS.SetActive(true);
                                    }
                                }

                                gPos.confirmed = "null";
                            }

                            
                        }
                        else if (boat.transform.position == gPos.boatEnd)
                        {
                            failed = FailCheck("end");
                            if (failed == true)
                            {
                                // Shows a pop up that will ask the user if they want to make that move
                                confirmCanvas.SetActive(true);
                                if (gPos.tts == true)
                                {
                                    confirmTTS.SetActive(true);
                                }
                                StartCoroutine("EndWaitUntil");
                            }
                            else
                            {
                                // Increases the number of moves and changes the text to show the number of moves
                                moves = moves + 1;
                                moveLabel.text = moves.ToString();

                                // Changes the boat's position
                                boatEndMove = true;

                                // For each animal that is in the boat it will check which animal it is and then move it
                                foreach  (string element in boatList)
                                {
                                    if (element == "dino")
                                    {
                                        dinoEndMove = true;
                                    }
                                    else if (element == "cow")
                                    {
                                        cowEndMove = true;
                                    }
                                    else if (element == "duck")
                                    {
                                        duckEndMove = true;
                                    }
                                    else if (element == "beans")
                                    {
                                        beansEndMove = true;
                                    }
                                }
                        
                                failed = FailCheck("start");
                                if (failed == true)
                                {
                                    failCanvas.SetActive(true);
                                    if (gPos.tts == true)
                                    {
                                        failTTS.SetActive(true);
                                    }
                                }

                                gPos.confirmed = "null";
                            }
                        }
                    }
                    else
                    {
                        // Increases the number of moves and changes the text to show the number of moves
                        moves = moves + 1;
                        moveLabel.text = moves.ToString();

                        if (boat.transform.position == gPos.boatStart)
                        {
                            // Changes the boat's position
                            boatStartMove = true;

                            // For each animal that is in the boat it will check which animal it is and then move it
                            foreach  (string element in boatList)
                            {
                                if (element == "dino")
                                {
                                    dinoStartMove = true;
                                }
                                else if (element == "cow")
                                {
                                    cowStartMove = true;
                                }
                                else if (element == "duck")
                                {
                                    duckStartMove = true;
                                }
                                else if (element == "beans")
                                {
                                    beansStartMove = true;
                                }
                            }
                        
                            failed = FailCheck("start");
                            if (failed == true)
                            {
                                failCanvas.SetActive(true);
                                if (gPos.tts == true)
                                {
                                    failTTS.SetActive(true);
                                }
                            }
                        }
                        else if (boat.transform.position == gPos.boatEnd)
                        {
                            // Changes the boat's position
                            boatEndMove = true;

                            // For each animal that is in the boat it will check which animal it is and then move it
                            foreach  (string element in boatList)
                            {
                                if (element == "dino")
                                {
                                    dinoEndMove = true;
                                }
                                else if (element == "cow")
                                {
                                    cowEndMove = true;
                                }
                                else if (element == "duck")
                                {
                                    duckEndMove = true;
                                }
                                else if (element == "beans")
                                {
                                    beansEndMove = true;
                                }
                            }

                            failed = FailCheck("end");
                            if (failed == true)
                            {
                                failCanvas.SetActive(true);
                                if (gPos.tts == true)
                                {
                                    failTTS.SetActive(true);
                                }
                            }
                        }
                    }
                }
                break;
        }
    }

    // FailCheck will check all of the ways that a player can lose a game and will output true if they have failed
    public bool FailCheck(string bank)
    {
        switch (bank)
        {
            case "start":
                if (startList.Contains("dino") && startList.Contains("cow"))
                {
                    return true;
                }
                else if (startList.Contains("dino") && startList.Contains("duck"))
                {
                    return true;
                }
                else if (startList.Contains("cow") && startList.Contains("duck"))
                {
                    return true;
                }
                else if (startList.Contains("cow") && startList.Contains("beans"))
                {
                    return true;
                }
                else if (startList.Contains("duck") && startList.Contains("beans"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            
            case "end":
                if (endList.Contains("dino") && endList.Contains("cow"))
                {
                    return true;
                }
                else if (endList.Contains("dino") && endList.Contains("duck"))
                {
                    return true;
                }
                else if (endList.Contains("cow") && endList.Contains("duck"))
                {
                    return true;
                }
                else if (endList.Contains("cow") && endList.Contains("beans"))
                {
                    return true;
                }
                else if (endList.Contains("duck") && endList.Contains("beans"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            
            default:
                return false;
        }
    }

    // WinCheck will check if the player has won the game and will return true or false
    public bool WinCheck()
    {
        if (endList.Count == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // This is only run in easy mode, the code will wait for the players input before continuing
    IEnumerator StartWaitUntil()
    {
        yield return new WaitUntil(() => gPos.confirmed != "null");

        confirmCanvas.SetActive(false);
        confirmTTS.SetActive(false);

        if (gPos.confirmed == "true")
        {
            // Increases the number of moves and changes the text to show the number of moves
            moves = moves + 1;
            moveLabel.text = moves.ToString();

            // Changes the boat's position
            boatStartMove = true;

            // For each animal that is in the boat it will check which animal it is and then move it
            foreach  (string element in boatList)
            {
                if (element == "dino")
                {
                    dinoStartMove = true;
                }
                else if (element == "cow")
                {
                    cowStartMove = true;
                }
                else if (element == "duck")
                {
                    duckStartMove = true;
                }
                else if (element == "beans")
                {
                    beansStartMove = true;
                }
            }
                        
            failed = FailCheck("start");
            if (failed == true)
            {
                failCanvas.SetActive(true);
                if (gPos.tts == true)
                {
                    failTTS.SetActive(true);
                }
            }

            gPos.confirmed = "null";
        }
        else if (gPos.confirmed == "false")
        {
            gPos.confirmed = "null";
        }
    }

    // This is only run in easy mode, the code will wait for the players input before continuing
    IEnumerator EndWaitUntil()
    {
        yield return new WaitUntil(() => gPos.confirmed != "null");

        confirmCanvas.SetActive(false);
        confirmTTS.SetActive(false);

        if (gPos.confirmed == "true")
        {
            // Increases the number of moves and changes the text to show the number of moves
            moves = moves + 1;
            moveLabel.text = moves.ToString();

            // Changes the boat's position
            boatEndMove = true;

            // For each animal that is in the boat it will check which animal it is and then move it
            foreach  (string element in boatList)
            {
                if (element == "dino")
                {
                    dinoEndMove = true;
                }
                else if (element == "cow")
                {
                    cowEndMove = true;
                }
                else if (element == "duck")
                {
                    duckEndMove = true;
                }
                else if (element == "beans")
                {
                    beansEndMove = true;
                }
            }
                        
            failed = FailCheck("end");
            if (failed == true)
            {
                failCanvas.SetActive(true);
                if (gPos.tts == true)
                {
                    failTTS.SetActive(true);
                }
            }

            gPos.confirmed = "null";
        }
        else if (gPos.confirmed == "false")
        {
            gPos.confirmed = "null";
        }
    }
}