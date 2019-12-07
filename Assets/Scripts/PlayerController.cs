using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int catLayerMask;

    [SerializeField]
    float moveSpeed = 1f;
    [SerializeField]
    float pickupRange = 1f;
    Transform cat;

    float lastInput = 0;

    private void Start()
    {
        catLayerMask = LayerMask.GetMask("Cat");
    }

    private void Update()
    {
        float input = Input.GetAxisRaw("Jump");
        
        if (lastInput == 0 && lastInput != input)
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

        lastInput = input;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}
