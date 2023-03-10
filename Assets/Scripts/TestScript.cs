using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    [SerializeField] private Text TestText;
    private int second = 0;
    private void FixedUpdate() {
        second++;
        TestText.text = second + ".th Test Completed\nSince The Program Started!";
    }
}
