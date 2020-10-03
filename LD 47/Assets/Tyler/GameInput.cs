using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private InputManager input;

    public int speed;
    public Rigidbody2D rb;

    private void Start()
    {
        input = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (input.state == InputManager.GameState.GAME)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 vect = new Vector3(horizontal, vertical, 0);
            vect = vect.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.transform.position + vect);
        }
    }
}
