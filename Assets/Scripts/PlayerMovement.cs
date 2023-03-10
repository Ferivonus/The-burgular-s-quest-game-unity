using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private Rigidbody playerRB;
    // [SerializeField] private anim

    private float xDirection = 0f;
    private float yDirection = 0f;

    void Update()
    {
        GetMovement();
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(new Vector3(xDirection * moveSpeed, 0, yDirection * moveSpeed));
    }

    void GetMovement()
    {
        xDirection = Input.GetAxis("Vertical");
        Debug.Log(xDirection);
        yDirection = Input.GetAxis("Horizontal");
    }
}
