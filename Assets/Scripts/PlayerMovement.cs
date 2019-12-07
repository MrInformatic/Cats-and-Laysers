using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}
