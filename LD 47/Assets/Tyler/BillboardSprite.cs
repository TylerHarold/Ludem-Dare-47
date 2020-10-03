using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    // Place this on the player sprite :)
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
