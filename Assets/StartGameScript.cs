using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This code is very simele and is used to load a new scene when a button is pressed
public class StartGameScript : MonoBehaviour
{
    // The name of the scene you want to go 
    // It should match how it is named in the build settings (ie: no spaces)
    public string NextScene;

    // Called when the button in clicked
    public void loadIntroScene()
    {
        SceneManager.LoadScene(NextScene);
    }

}