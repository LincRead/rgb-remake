using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    [Header("Player ship")]
    public GameObject playerShip;
    public float playerSpawnPointX;

	// Use this for initialization
	void Start () {
        InitLevel();
	}

    public void InitLevel() {
        // Invoke("CompletedLevel", 3f);
        GameObject.Instantiate(playerShip, new Vector2(playerSpawnPointX, 5.4f), Quaternion.identity);
    }

    public void CompletedLevel() {
        Debug.Log("COMPLETED");
        SceneManager.LoadScene("victory");
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Invoke("GoToGameOverScreen", 2f);
        
    }

    void GoToGameOverScreen()
    {
        SceneManager.LoadScene("idlegame");
    }
}
