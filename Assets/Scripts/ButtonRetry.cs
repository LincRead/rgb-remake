﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonRetry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("game");
        }
    }
}
