using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    float timeSinceLastEnemySpawned = 0.0f;

    public float minTimeBetweenEnemiesSpawn = 0.8f;
    public float maxTimeBetweenEnemiesSpawn = 1.5f;
    public float decreaseTimePerMin = 0.7f;

    private float timeBetweenEnemySpawn = 1f;

    private bool doneSpawningEnemie = false;
    private float timeToSpawnBoss = 2f;
    private float timeSinceAllEnemiesDefeated = 0.0f;

    // Use this for initialization
    void Start () {
        timeBetweenEnemySpawn = maxTimeBetweenEnemiesSpawn;

    }
	
	// Update is called once per frame
	void Update () {

        if(doneSpawningEnemie)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
            {
                timeSinceAllEnemiesDefeated += Time.deltaTime;
                if(timeSinceAllEnemiesDefeated >= timeToSpawnBoss)
                    SceneManager.LoadScene("boss");
            }
               
            return;
        }

        timeSinceLastEnemySpawned += Time.deltaTime;
        if (timeSinceLastEnemySpawned > timeBetweenEnemySpawn)
        {
            timeSinceLastEnemySpawned = 0.0f;

            float sizey = enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
            float posx = 19.2f + enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            float posy = (sizey / 2) + (Random.value * (10.8f - sizey));
            GameObject newEnemy = GameObject.Instantiate(enemyPrefab, new Vector3(posx, posy, 0.0f), Quaternion.identity) as GameObject;

            int ranc = (int)((Random.value * 0.99f) * 3);

            switch(ranc)
            {
                case 0: newEnemy.GetComponent<Enemy>().SetColor(COLOR.RED); break;
                case 1: newEnemy.GetComponent<Enemy>().SetColor(COLOR.GREEN); break;
                case 2: newEnemy.GetComponent<Enemy>().SetColor(COLOR.BLUE); break;
                default: newEnemy.GetComponent<Enemy>().SetColor(COLOR.RED); break;
            }
        }

        timeBetweenEnemySpawn -= ((decreaseTimePerMin * Time.deltaTime) / 60);
        if(timeBetweenEnemySpawn <= minTimeBetweenEnemiesSpawn)
        {
            timeBetweenEnemySpawn = minTimeBetweenEnemiesSpawn;

            // Finished enemies!
            doneSpawningEnemie = true;
        }
    }
}
