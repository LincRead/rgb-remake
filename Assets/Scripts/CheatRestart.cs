using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheatRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Hold down a combination of buttons on pad to reset application
        if (Input.GetButton("Fire1")
             && Input.GetButton("Fire4")
             && Input.GetButton("Start"))
        {
            SceneManager.LoadSceneAsync("intro");
        }
	}
}
