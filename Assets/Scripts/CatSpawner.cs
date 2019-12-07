using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject cat;
    public int count;

    void Start() 
    {
        for(int i = 0; i < count; i++) 
        {
            Instantiate(cat);
        }
    }
}
