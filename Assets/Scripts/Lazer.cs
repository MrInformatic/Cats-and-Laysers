using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Tower tower;
    public HFTInput hFTInput;

    float lastTakeInput = 0f;
    float lastUseInput = 0f;

    void Update()
    {
        if (hFTInput != null) {
            float takeInput = hFTInput.GetAxisRaw("Jump");
            float useInput = hFTInput.GetAxisRaw("Fire1");

            if (hFTInput.GetButtonDown("Fire1"))
            {
                tower.Exit();
            }

            lastTakeInput = takeInput;
            lastUseInput = useInput;
        }
    }
}
