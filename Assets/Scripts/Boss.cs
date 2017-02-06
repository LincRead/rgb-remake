using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    bool defeated = false;

    float timeSinceDefeated = 0.0f;
    float timeToOpenVideoAfterDefeat = 0.8f;

    float spawnX;

    bool charging = false;
    bool goBack = false;
    float chargeSpeed = 5f;
    float timeSinceCharge = 0.0f;
    float timeToCharge = 4.0f;

    AudioSource audioSource;

	void Start () {
        spawnX = transform.position.x;

        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {

    }
	
	void Update () {

        transform.position = new Vector3(transform.position.x, 5.4f + (Mathf.Sin(Time.time * 1.8f) * 2f), 0);

        if (GameObject.FindGameObjectsWithTag("VideoStory").Length != 0)
            return;

        if (defeated)
        {
            timeSinceDefeated += Time.deltaTime;
            if (timeSinceDefeated > timeToOpenVideoAfterDefeat)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().CompletedLevel();
            }
        }

        if (!charging)
        {
            timeSinceCharge += Time.deltaTime;
            if(timeSinceCharge >= timeToCharge)
            {
                audioSource.Play();

                charging = true;
            }
        }

        else
        {
            if (!goBack && transform.position.x > 4f)
            {
                transform.position -= new Vector3(chargeSpeed * Time.deltaTime, 0, 0);

                if(transform.position.x <= 4)
                {
                    goBack = true;
                    transform.position = new Vector3(4f, 5.4f + (Mathf.Sin(Time.time * 1.8f) * 2f), transform.position.z);
                }
            }

            else if(goBack && transform.position.x < spawnX)
            {
                transform.position += new Vector3(chargeSpeed * Time.deltaTime, 0, 0);

                if (transform.position.x >= spawnX)
                {
                    charging = false;
                    goBack = false;
                    transform.position = new Vector3(spawnX, 5.4f + (Mathf.Sin(Time.time * 1.8f) * 2f), transform.position.z);
                    timeSinceCharge = 0.0f;
                }
            }
        }

        if (GameObject.FindGameObjectsWithTag("BossObject").Length <= 0)
        {
            if(!defeated)
                DefeatBoss();
        }
	}

    void DefeatBoss()
    {
        defeated = true;
        timeSinceDefeated = 0.0f;
    }
}
