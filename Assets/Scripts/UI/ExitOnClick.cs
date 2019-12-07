using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitOnClick : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        Application.Quit();
    }
}
