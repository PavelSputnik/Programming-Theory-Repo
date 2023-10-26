using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(LoadYourAsyncScene());
        // SceneManager.LoadScene(1, LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    IEnumerator LoadYourAsyncScene()
    {
        

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
