using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stealable : MonoBehaviour
{
    [SerializeField] private int itemValue;

    private TextMeshProUGUI screenText;
    private bool itemInRange = false;
    private bool hasStolen = false;


    void Start()
    {
        screenText = FindObjectOfType<TextMeshProUGUI>();
        screenText.text = "";
    }

    private void Update()
    {
        if (itemInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                hasStolen = true;
                screenText.text = "";
            }

            if (hasStolen == false)
            {
                screenText.text = "Press 'F' to Steal\nWorth: " + itemValue + " Gold";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            itemInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            screenText.text = "";
            itemInRange = false;
        }
    }
}
