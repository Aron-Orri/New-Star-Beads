using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioContext { Menus, Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8 };

public class AudioSourceContext : MonoBehaviour
{
    [SerializeField] private AudioContext currentContext;

    public AudioContext GetCurrentAudioContext()
    {
        return currentContext;
    }

    public void SetCurrentAudioContext(AudioContext newContext)
    {
        currentContext = newContext;
    }


}
