using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class WinState : MonoBehaviour
{
    private TextMeshProUGUI screenText;
    private bool hasExited = false;

    private float timer = 3;
    private bool timerIsRunning = false;

    void Start()
    {
        screenText = FindObjectOfType<TextMeshProUGUI>();
        screenText.text = "";
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Cursor.visible = true;
                timerIsRunning = false;
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasExited == true)
        {
            screenText.text = "Press 'F' to Exit";

            if (Input.GetKeyDown(KeyCode.F))
            {
                timerIsRunning = true;
                screenText.text = "Heist was succesfull!!";
                //he will cannot move in this area
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            screenText.text = "";
            hasExited = true;
        }
    }
}
