using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Transform gameoverCanvas;
    public Transform hideCanvas;
    
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R)) //R restarts game from begining
        {
            SceneManager.LoadScene("main", LoadSceneMode.Single);
            Time.timeScale = 1; //unfreeze time
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) //colliding with the enemy, ends the game
        {
            hideCanvas.gameObject.SetActive(false); //turn off the hidecanvas
            gameoverCanvas.gameObject.SetActive(true);//turn on the gameovercanvas
            Time.timeScale = 0;//freeze time

        
        }
    }
}
