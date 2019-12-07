using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HFTInput), typeof(HFTGamepad))]
public class PlayerController : MonoBehaviour
{
    private int pickupLayerMask;
    private int towerLayerMask;
    //public Renderer renderer;

    [SerializeField]
    float pickupRange = 1f;
    [SerializeField]
    float enterRange = 1f;
    Transform hand;


    HFTInput m_hftInput;
    HFTGamepad m_gamepad;

    void Drop()
    {
        Debug.Log("Dropping");

        if (hand != null)
        {
            CatAI catAI = hand.GetComponent<CatAI>();
            if(catAI != null)
            {
                catAI.enabled = true;
            }

            hand.parent = null;
            hand = null;
        }
    }

    void PickUp(Transform entity)
    {
        Debug.Log("Picking up");
        hand = entity;
        entity.parent = transform;

        CatAI catAI = entity.GetComponent<CatAI>();
        if(catAI != null)
        {
            catAI.enabled = false;
        }
    }

    private void Start()
    {
        pickupLayerMask = LayerMask.GetMask("Cat", "Item");
        towerLayerMask = LayerMask.GetMask("Tower");

        m_hftInput = GetComponent<HFTInput>();

        m_gamepad = GetComponent<HFTGamepad>();

        //renderer.material.color = m_gamepad.color;
    }

    private void Update()
    {
        if (m_hftInput.GetButtonDown("Fire2"))
        {
            Debug.Log("Button Press");
            // Collect
            if (hand == null)
            {
                Collider2D collider = Physics2D.OverlapCircle(transform.position, enterRange, pickupLayerMask);
                if (collider != null) {
                    PickUp(collider.transform);
                }
            }
            // Drop
            else
            {
                Drop();
            }
        }

        if (m_hftInput.GetButtonDown("Fire1"))
        {
            // Use
            Collider2D collider = Physics2D.OverlapCircle(transform.position, pickupRange, towerLayerMask);
            if (collider != null && collider.CompareTag("Tower"))
            {
                Debug.Log("Enter Tower");

                Drop();
                Tower tower;
                if (collider.TryGetComponent<Tower>(out tower))
                {
                    Debug.Log("TEst");
                    tower.Enter(transform, m_hftInput);
                }
            }
            else if (hand)
            {
                // Use item
            }
        }
    }
}
