using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Tower tower;

    float lastTakeInput = 0f;
    float lastUseInput = 0f;

    void Update()
    {
        float takeInput = Input.GetAxisRaw("Jump");
        float useInput = Input.GetAxisRaw("Fire1");

        if (lastTakeInput == 0 && lastTakeInput != takeInput) 
        {

        }
        if (lastUseInput == 0 && lastUseInput != useInput)
        {
            tower.Exit();
        }

        lastTakeInput = takeInput;
        lastUseInput = useInput;
    }
}
