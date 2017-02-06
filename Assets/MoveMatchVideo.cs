using UnityEngine;
using System.Collections;

public class MoveMatchVideo : MonoBehaviour {

    Renderer r;
    MovieTexture movie;

    // Use this for initialization
    void Start () {
        r = GetComponent<Renderer>();
        movie = (MovieTexture)r.material.mainTexture;
        movie.Play();
        movie.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
