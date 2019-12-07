using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Area : MonoBehaviour
{
    public UnityEvent onCatCountChangeEvent;
    
    private int _catCount;

    public int CatCount 
    {
        get 
        {
            return _catCount;
        } 
        set 
        {
            var oldCatCount = _catCount;
            _catCount = value;
            if(oldCatCount != _catCount) {
                onCatCountChangeEvent.Invoke();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        CatCount++;
    }

    void OnTriggerExit2D(Collider2D collider) {
        CatCount--;
    }
}
