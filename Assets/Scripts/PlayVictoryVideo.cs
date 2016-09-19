using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayVictoryVideo : MonoBehaviour
{
    public AudioClip videoAudio;

    private AudioSource audioSource;
    private float timeSincePlay = 0.0f;
    private float duration;
    private bool startedPlayingVideo = false;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = videoAudio;
    }

    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        duration = movie.duration;

        if (!movie.isPlaying)
        {
            movie.Play();
            audioSource.Play();

            timeSincePlay = 0.0f;
            startedPlayingVideo = true;
        }

        // Jump becomes skip video button
        if (Input.GetButtonDown("Jump"))
        {
            // Go to next scene
            SceneManager.LoadScene("video");
        }

        timeSincePlay += Time.deltaTime;
        if (timeSincePlay > duration)
        {
            // Go to next scene
            SceneManager.LoadScene("video");
        }
    }
}
