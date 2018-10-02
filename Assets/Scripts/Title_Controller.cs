
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_Controller : MonoBehaviour {
    public Button playButton;
    public Button exitButton;

    public void Play()
    {
        SceneManager.LoadScene("Scenes/Main");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
