using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HFTInput), typeof(HFTGamepad))]
public class PlayerController : MonoBehaviour
{
    public Renderer renderer;

    private int catLayerMask;

    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    float pickupRange = 1f;
    Transform cat;

    //float lastInput = 0;

    HFTInput m_hftInput;
    HFTGamepad m_gamepad;

    private void Start()
    {
        m_hftInput = GetComponent<HFTInput>();
        catLayerMask = LayerMask.GetMask("Cat");

        m_gamepad = GetComponent<HFTGamepad>();

        renderer.material.color = m_gamepad.color;
    }

    private void Update()
    {
        //float input = m_hftInput.GetButton("Fire1");
        
        if (m_hftInput.GetButtonDown("Fire1"))
        {
            // Collect cat
            if (cat == null)
            {
                Collider2D collider = Physics2D.OverlapCircle(transform.position, pickupRange, catLayerMask);
                if (collider != null) {
                    Debug.Log("Picking up cat");
                    cat = collider.transform;
                    cat.parent = transform;
                    // cat.position = new Vector3();
                }
            }
            // Drop cat
            else
            {
                Debug.Log("Dropping cat");
                // cat.position = transform.position;
                cat.parent = null;
                cat = null;
            }
        }

        //lastInput = input;
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
