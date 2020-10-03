using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] CharacterController Player;
    [SerializeField] int moveSpeed = 12;

    [Header("Jump")]
    [SerializeField] Transform GroundCheck;
    [SerializeField] float groundDistance = .5f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpHeight = 3f;
    Vector3 fallingVelocity;
    float gravity = -9.81f;

    bool isGrounded;

    [Header("StringsVariables")]
    string horizontal = "Horizontal";
    string vertical = "Vertical";
    string jump = "Jump";

    void Update()
    {
        MoveControls();
        Gravity();
        Jump();
    }

    void MoveControls()
    {
        float x = Input.GetAxis(horizontal);
        float z = Input.GetAxis(vertical);

        Vector3 movement = transform.right * x + transform.forward * z;
        Player.Move(movement * moveSpeed * Time.deltaTime);
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && fallingVelocity.y < 0)
        {
            fallingVelocity.y = -1f;
        }
        else
        {
            fallingVelocity.y += gravity * Time.deltaTime;
            Player.Move(fallingVelocity * Time.deltaTime);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown(jump) && isGrounded)
        {
            fallingVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
