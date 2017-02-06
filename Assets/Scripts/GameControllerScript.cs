using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    [Header("Player ship")]
    public GameObject playerShip;
    public float playerSpawnPointX;

	void Start () {
        InitLevel();
	}

    public void InitLevel() {
        GameObject.Instantiate(playerShip, new Vector2(playerSpawnPointX, 5.4f), Quaternion.identity);
    }

    public void CompletedLevel() {
        SceneManager.LoadScene("victory");
    }

    public void GameOver()
    {
        if (GameObject.FindGameObjectsWithTag("Boss").Length == 0)
            Invoke("GoToGameOverScreen", 2f);
        else
            Invoke("RestartBoss", 2f);
    }

    void GoToGameOverScreen()
    {
        SceneManager.LoadScene("idlegame");
    }

    void RestartBoss()
    {
        SceneManager.LoadScene("boss");
    }
}
