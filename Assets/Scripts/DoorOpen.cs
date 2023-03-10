using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private bool isSliding = true;
    [SerializeField] private bool minusZ = false;
    [SerializeField] private float rotateAmount = 80f;

    private TextMeshProUGUI screenText;
    private float slideAmount = 1.5f;
    private bool isAlreadyOppened = false;
    private bool doorInRange = false;

    private void Start()
    {
        screenText = FindObjectOfType<TextMeshProUGUI>();
        screenText.text = "";
    }

    private void LateUpdate()
    {
        if (doorInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isSliding == true)
                {
                    if (minusZ == false)
                    {
                        if (isAlreadyOppened == true)
                        {
                            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - slideAmount);
                            isAlreadyOppened = false;
                        }
                        else
                        {
                            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + slideAmount);
                            isAlreadyOppened = true;
                        }
                    }
                    else
                    {
                        if (isAlreadyOppened == true)
                        {
                            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + slideAmount);
                            isAlreadyOppened = false;
                        }
                        else
                        {
                            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - slideAmount);
                            isAlreadyOppened = true;
                        }
                    }
                }
                else if (isSliding == false)
                {
                    if (isAlreadyOppened == true)
                    {
                        gameObject.transform.Rotate(0, rotateAmount, 0);
                        isAlreadyOppened = false;
                    }
                    else
                    {
                        gameObject.transform.Rotate(0, -rotateAmount, 0);
                        isAlreadyOppened = true;
                    }
                }
            }
            if (isAlreadyOppened == false)
                screenText.text = "Press 'F' to Open";
            else
                screenText.text = "Press 'F' to Close";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            screenText.text = "";
            doorInRange = false;
        }
    }
}
