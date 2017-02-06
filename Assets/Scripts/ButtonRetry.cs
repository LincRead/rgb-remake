using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonRetry : MonoBehaviour {

	void Start () {
	    
	}
	
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("game");
        }
    }
}
