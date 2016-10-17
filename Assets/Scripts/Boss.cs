using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    bool defeated = false;

    float timeSinceDefeated = 0.0f;
    float timeToOpenVideoAfterDefeat = 0.8f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (defeated)
        {
            timeSinceDefeated += Time.deltaTime;
            if (timeSinceDefeated > timeToOpenVideoAfterDefeat)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().CompletedLevel();
            }
        }

        transform.position = new Vector3(transform.position.x, 5.4f + (Mathf.Sin(Time.time * 1.8f) * 2f), 0);

        if(GameObject.FindGameObjectsWithTag("BossObject").Length <= 0)
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
