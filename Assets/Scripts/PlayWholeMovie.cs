using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayWholeMovie : MonoBehaviour
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

        r.enabled = false;

        if (playAtInit)
            PlayVideo();
    }

    public void PlayVideo()
    {
        movie = (MovieTexture)r.material.mainTexture;
        duration = movie.duration;

        movie.Play();
        audioSource.Play();

        transform.position = new Vector3(9.6f, 5.4f, -1);

        timeSincePlay = 0.0f;
        startedPlayingVideo = true;
    }

    void Update()
    {
        if (PressingAnyFireButton())
        {
            if (movie.isPlaying && startedPlayingVideo)
            {
                SceneManager.LoadScene("intro");
            }
        }

        if (startedPlayingVideo)
        {
            timeSincePlay += Time.deltaTime;
            if(timeSincePlay > 1)
                r.enabled = true;

            if (timeSincePlay > duration)
            {
                SceneManager.LoadScene("intro");
            }
        }

        if (!movie.isPlaying)
        {
            transform.position = new Vector3(9.6f, 5.4f, 1);
        }
    }

    bool PressingAnyFireButton()
    {
        if (Input.GetButtonDown("Fire1"))
            return true;

        return false;
    }
}
