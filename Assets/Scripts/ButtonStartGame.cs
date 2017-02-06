using UnityEngine;
using System.Collections;

public class ButtonStartGame : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().InitLevel();
            Destroy(gameObject);
        }
    }
}
