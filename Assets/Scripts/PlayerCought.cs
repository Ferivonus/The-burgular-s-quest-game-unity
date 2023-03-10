using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerCought : MonoBehaviour
{
    private TextMeshProUGUI screenText;

    private float timeRemaining = 10;
    private bool timerIsRunning = false;
    


    void Start()
    {
        screenText = FindObjectOfType<TextMeshProUGUI>();
        screenText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timerIsRunning = true;
            GameOver();
        }
    }

    private void GameOver()
    {
        screenText.text = "You Get Caught! Run to your base!";
        screenText.text += "\n";
        screenText.text += "You have 10 seconds";
    }

    bool gameEnds;

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                screenText.text = "You lost.";
                timeRemaining = 0;
                timerIsRunning = false;
                gameEnds = true;
            }
        }
        else if (gameEnds)
        {
            if (timeRemaining < 4)
            {
                timeRemaining += Time.deltaTime;
            }
            else
            {
                timeRemaining = 4;
                gameEnds = false;
                Cursor.visible = true;
                SceneManager.LoadScene(0);
            }
        }
    }

}

/*
  else if (tour != 1)
            {
                Debug.Log("Hiding purpose worked.");
                //calling the function, inside of the function
                //to set new time for losing game.
                timer = 0;
                timerIsRunning = false;
                screenText.text = "You Losed the game";
                TimerFunc(1, 3f, true);
            }
            else
            {
                timer = 0;
                timerIsRunning = false;
                Cursor.visible = true;
                SceneManager.LoadScene(0);
            }
 */