using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx3 : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    static AudioSource audioSource;
    public static AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Pill2");
    }

    // Update is called once per frame
    public static void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
