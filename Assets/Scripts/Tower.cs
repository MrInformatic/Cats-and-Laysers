using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    Transform seatPosition;
    [SerializeField]
    Transform lazer;
    Transform player;
    Vector3 playerPosition;
    int sortingLayer;

    public void Enter(Transform player)
    {
        // Player stuff
        this.player = player;
        player.parent = seatPosition;
        playerPosition = player.position;
        player.localPosition = new Vector3();
        SpriteRenderer renderer = player.GetComponentInChildren<SpriteRenderer>();
        sortingLayer = renderer.sortingOrder;
        renderer.sortingOrder = 4;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;

        // Lazer
        lazer.gameObject.SetActive(true);
    }

    public void Exit()
    {
        // Player stuff
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
        SpriteRenderer renderer = player.GetComponentInChildren<SpriteRenderer>();
        renderer.sortingOrder = sortingLayer;
        sortingLayer = 0;
        player.position = playerPosition;
        playerPosition = new Vector3();
        player.parent = null;
        player = null;

        // Lazer
        lazer.gameObject.SetActive(false);
    }
}
