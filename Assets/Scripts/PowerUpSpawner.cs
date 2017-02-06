using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

    public float timeBetweenPowerUpSpawn = 8f;
    public GameObject powerUpPrefab;

    float timeSinceLastPowerUpSpawned = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastPowerUpSpawned += Time.deltaTime;

        // Time to spawn new powerup
        if (timeSinceLastPowerUpSpawned >= timeBetweenPowerUpSpawn)
        {
            timeSinceLastPowerUpSpawned = 0.0f;

            float sizey = powerUpPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
            float posx = 19.2f + powerUpPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            float posy = .5f + (sizey / 2) + (Random.value * (10.8f - sizey - 1f));
            GameObject.Instantiate(powerUpPrefab, new Vector3(posx, posy, 0.0f), Quaternion.identity);
        }
    }
}
