using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour {

    public Transform crouchCanvas;//canvas with crouch instruction

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //trigger to display tip
            {
            StartCoroutine(change());
              
            }
        
    }

    IEnumerator change()
    {
        crouchCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(5); //have the canvas up for 5 seconds then go away
        crouchCanvas.gameObject.SetActive(false);
    }
}
