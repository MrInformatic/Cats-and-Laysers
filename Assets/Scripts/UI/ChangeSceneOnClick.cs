using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        SceneManager.LoadScene(sceneName);        
    }
}
