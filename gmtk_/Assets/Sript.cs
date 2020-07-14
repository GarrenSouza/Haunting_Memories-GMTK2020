using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sript : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip musicIntro, musicLoop;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        _audioSource.clip = musicIntro;
        _audioSource.Play();
        //_audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = musicLoop;
            _audioSource.Play();
        }

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
}
