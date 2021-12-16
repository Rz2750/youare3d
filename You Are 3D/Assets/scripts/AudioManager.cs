using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource _audioSource;
    static public Slider volumeSlider;
    private GameObject[] other;
    private bool NotFirst = false;
    private void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }

        if (NotFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
    
    public void changeVolume(float sliderValue)
    {
        _audioSource.volume = sliderValue;
    }
}