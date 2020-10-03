using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 vect = new Vector3(horizontal, vertical, 0);
        vect = vect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + vect);
    }
}
