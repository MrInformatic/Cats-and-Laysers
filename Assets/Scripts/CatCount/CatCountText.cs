using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CatCountText : MonoBehaviour
{
    public Area area;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        area.onCatCountChangeEvent.AddListener(OnCatCountChange);
    }

    void OnCatCountChange() 
    {
        text.text = "Cat Count: " + area.CatCount;
    }
}
