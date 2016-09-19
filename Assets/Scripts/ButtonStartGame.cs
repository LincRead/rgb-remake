using UnityEngine;
using System.Collections;

public class ButtonStartGame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().InitLevel();
            Destroy(gameObject);
        }
    }
}
