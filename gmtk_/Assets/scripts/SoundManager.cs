using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip jumpClip;
    [SerializeField]
    private AudioClip energyClip;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    public void JumpSound()
    {
        soundFX.clip = jumpClip;
        soundFX.Play();
    }
    public void EnergySound()
    {
        soundFX.clip = energyClip;
        soundFX.Play();
    }

}
