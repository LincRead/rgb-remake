using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayStoryVideo : MonoBehaviour
{
    Renderer r;
    MovieTexture movie;

    public AudioClip videoAudio;
    private AudioSource audioSource;

    private float timeSincePlay = 0.0f;
    private float duration;
    private bool startedPlayingVideo = false;

    public string nextScene = "";

    public bool playAtInit = false;

    // Use this for initialization
    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = videoAudio;

        r = GetComponent<Renderer>();
        movie = (MovieTexture)r.material.mainTexture;
        movie.Stop();

        if (playAtInit)
            PlayVideo();
    }

    public void PlayVideo()
    {
        movie = (MovieTexture)r.material.mainTexture;
        duration = movie.duration;

        movie.Play();
        audioSource.Play();

        timeSincePlay = 0.0f;
        startedPlayingVideo = true;
    }

    void Update()
    {
        /* if (PressingAnyFireButton())
        {
            if (movie.isPlaying)
            {
                if(nextScene != "")
                    SceneManager.LoadScene(nextScene);
                else
                    Destroy(gameObject);
            }
        } */

        if(startedPlayingVideo)
        {
            timeSincePlay += Time.deltaTime;
            if(timeSincePlay > duration)
            {
                if (nextScene != "")
                    SceneManager.LoadScene(nextScene);
                else
                    Destroy(gameObject);
            }
        }
    }

    bool PressingAnyFireButton()
    {
        if (Input.GetButtonDown("Fire1"))
            return true;

        return false;
    }
}
