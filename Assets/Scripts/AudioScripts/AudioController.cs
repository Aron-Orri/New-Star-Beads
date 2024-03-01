using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip currentSceneClip;
    [Range(0f,1f)]
    [SerializeField] private float volume = .5f;
    [SerializeField] private AudioContext currentSceneAudioContext;

    private readonly string audioSourceName = "BackgroundMusicAudioSource";

    private GameObject audioSourceObj;


    void Start()
    {
        audioSourceObj = GameObject.Find(audioSourceName);
        if (audioSourceObj == null )
        {
            audioSourceObj = new GameObject(audioSourceName);

            AudioSource audioSource = audioSourceObj.AddComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.volume = volume;
            audioSource.clip = currentSceneClip;
            audioSource.playOnAwake = false;

            AudioSourceContext audioSourceContext = audioSourceObj.AddComponent<AudioSourceContext>();
            audioSourceContext.SetCurrentAudioContext(currentSceneAudioContext);

            Instantiate(audioSourceObj, transform.position, transform.rotation);
            GameObject.DontDestroyOnLoad(audioSourceObj);

            audioSource.Play();
        } 
        else
        {
            AudioSourceContext audioSourceContext = audioSourceObj.GetComponent<AudioSourceContext>();
            if (currentSceneAudioContext != audioSourceContext.GetCurrentAudioContext())
            {
                audioSourceContext.SetCurrentAudioContext(currentSceneAudioContext);
                AudioSource audioSource = audioSourceObj.GetComponent<AudioSource>();
                audioSource.Stop();
                audioSource.clip = currentSceneClip;
                audioSource.Play();
            }
        }

        if (PlayerPrefs.GetInt("audioEnabled", 1) == 0) audioSourceObj.GetComponent<AudioSource>().Stop();
    }

    public void UpdateAudioSource()
    {
        var audioSource = audioSourceObj.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("audioEnabled", 1) == 1 && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else 
        { 
            audioSource.Stop(); 
        }
    }

}
