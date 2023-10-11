using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundMenager : MonoBehaviour
{   
    public enum Sounds
    {
        Bonus, Win, Lose
    }
    public AudioClip AddTime;
    public AudioClip WinAudio;
    public AudioClip LoseAudio;


    AudioSource audioSource;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SoundMenager").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);   
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.Bonus:
                audioSource.PlayOneShot(AddTime);
                break;
            case Sounds.Win:
                audioSource.PlayOneShot(WinAudio);
                break;
            case Sounds.Lose:
                audioSource.PlayOneShot(LoseAudio);
                break;
            default:
                break;
        }
    }

}
