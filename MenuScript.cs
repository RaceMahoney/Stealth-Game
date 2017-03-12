using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Transform MenuCanvas;
    public Transform LoadingCanvas;

  
	public void OnStartGame() //function on start button to load the main scene
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
        MenuCanvas.gameObject.SetActive(false);
        LoadingCanvas.gameObject.SetActive(true);
    }

   

    public void Quit() //function to exit the game
    {
        Application.Quit();
    }
}
