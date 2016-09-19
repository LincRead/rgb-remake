using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    public GameObject playerShip;
    public Vector2 playerSpawnPoint;

	// Use this for initialization
	void Start () {
        InitLevel();
	}

    public void InitLevel() {
        Debug.Log("Inited level");

        // Invoke("CompletedLevel", 3f);
        GameObject.Instantiate(playerShip, new Vector2(1.28f, 5.4f), Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
	
	}

    void CompletedLevel() {
        Debug.Log("COMPLETED");
        SceneManager.LoadScene("victory");
    }
}
