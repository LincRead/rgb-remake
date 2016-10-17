using UnityEngine;
using System.Collections;

public class DestroyAfterSoundPlay : MonoBehaviour {

    float duration = 10f;
    float timeSinceStarted = 0.0f;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceStarted += Time.deltaTime;
        if (timeSinceStarted >= duration)
            Destroy(gameObject);
	}

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }
}
