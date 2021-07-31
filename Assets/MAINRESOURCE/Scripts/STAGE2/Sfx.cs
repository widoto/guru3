using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    // Start is called before the first frame update
    static AudioSource audioSource;
    public static AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Coin1");
    }

    // Update is called once per frame
    public static void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
