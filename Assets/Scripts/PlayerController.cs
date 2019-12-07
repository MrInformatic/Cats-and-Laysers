using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int pickupLayerMask;
    private int towerLayerMask;

    [SerializeField]
    float pickupRange = 1f;
    [SerializeField]
    float enterRange = 1f;
    Transform hand;

    float lastTakeInput = 0f;
    float lastUseInput = 0f;

    void Drop()
    {
        Debug.Log("Dropping");
        if (hand != null)
        {
            hand.parent = null;
            hand = null;
        }
    }

    void PickUp(Transform entity)
    {
        Debug.Log("Picking up");
        hand = entity;
        entity.parent = transform;
    }

    private void Start()
    {
        pickupLayerMask = LayerMask.GetMask("Cat", "Item");
        towerLayerMask = LayerMask.GetMask("Tower");
    }

    private void Update()
    {
        float takeInput = Input.GetAxisRaw("Jump");
        float useInput = Input.GetAxisRaw("Fire1");

        if (lastTakeInput == 0 && lastTakeInput != takeInput)
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

        if (lastUseInput == 0 && lastUseInput != useInput)
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
                    tower.Enter(transform);
                }
            }
            else if (hand)
            {
                // Use item
            }
        }

        lastTakeInput = takeInput;
        lastUseInput = useInput;
    }
}
