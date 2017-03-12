using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public Transform winCanvas; //canvas containg win canvas

    
    void OnTriggerEnter(Collider other) 
    {
        //checks if player has entered the trigger area
        if (other.gameObject.CompareTag("Player"))
        {
            winCanvas.gameObject.SetActive(true);
            Time.timeScale = 0; //pause the in game time

        }
    }


}
