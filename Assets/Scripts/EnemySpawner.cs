using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public float timeBetweenEnemySpawn = 1f;
    public GameObject enemyPrefab;

    float timeSinceLastEnemySpawned = 0.0f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastEnemySpawned += Time.deltaTime;
        if (timeSinceLastEnemySpawned > timeBetweenEnemySpawn)
        {
            timeSinceLastEnemySpawned = 0.0f;

            float sizey = enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
            float posx = 19.2f + enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            float posy = (sizey / 2) + (Random.value * (10.8f - sizey));
            GameObject newEnemy = GameObject.Instantiate(enemyPrefab, new Vector3(posx, posy, 0.0f), Quaternion.identity) as GameObject;

            int ranc = (int)((Random.value * 0.99f) * 3);
            Debug.Log(ranc);

            switch(ranc)
            {
                case 0: newEnemy.GetComponent<Enemy>().SetColor(COLOR.RED); break;
                case 1: newEnemy.GetComponent<Enemy>().SetColor(COLOR.GREEN); break;
                case 2: newEnemy.GetComponent<Enemy>().SetColor(COLOR.BLUE); break;
                default: newEnemy.GetComponent<Enemy>().SetColor(COLOR.RED); break;
            }
        }
    }
}
