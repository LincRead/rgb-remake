using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayMoreManager : MonoBehaviour {

    public GameObject videoLoop = null;
    public GameObject videoTransition = null;

    AudioSource audioSource;
    bool playedSound = false;
    bool openingNextScene = false;

    public string nextScene = "";

    // Use this for initialization
    void Start()
    {
       audioSource = GetComponent<AudioSource>();

        if (videoLoop == null)
            OpenNextScene();
    }

    void Update()
    {
        if (openingNextScene || videoLoop == null)
            return;

        if (!videoLoop.GetComponent<PlayMoreVideo>().videoPlaying.isPlaying)
        {
            videoLoop.GetComponent<PlayMoreVideo>().r.enabled = false;
            videoTransition.GetComponent<PlayMoreVideo>().Play(false);

            openingNextScene = true;
            Invoke("OpenNextScene", videoTransition.GetComponent<PlayMoreVideo>().videoPlaying.duration);
        }

        if(PressingAnyFireButton() && !playedSound)
        {
            audioSource.Play();
            playedSound = true;
        }
    }

    void OpenNextScene()
    {
        openingNextScene = true;

        GameObject[] videoObjects = GameObject.FindGameObjectsWithTag("VideoStory");
        if (videoObjects.Length > 0)
        {
            if (videoTransition)
                videoTransition.GetComponent<PlayMoreVideo>().r.enabled = false;

            videoObjects[0].GetComponent<PlayStoryVideo>().PlayVideo();
        }
        else if (nextScene != "")
            SceneManager.LoadScene(nextScene);
    }

    bool PressingAnyFireButton()
    {
        if(Input.GetButtonDown("Fire1")
            || Input.GetButtonDown("Fire2")
            || Input.GetButtonDown("Fire3")
            || Input.GetButtonDown("Fire4"))
            return true;

        return false;
    }
}

