using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIController : MonoBehaviour
{
    public SpielerController spielerBall;
    public Canvas UICanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UICanvas.enabled = true;
        }
    }

    public void StartGame()
    {
        UICanvas.enabled = false;
        spielerBall.enabled = true;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
