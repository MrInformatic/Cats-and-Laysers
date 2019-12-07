using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    HFTInput m_hftInput;
    HFTGamepad m_gamepad;

    void Start() 
    {
        m_hftInput = GetComponent<HFTInput>();

        m_gamepad = GetComponent<HFTGamepad>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            m_hftInput.GetAxis("Horizontal"),
            -m_hftInput.GetAxis("Vertical")
        );

        transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}
