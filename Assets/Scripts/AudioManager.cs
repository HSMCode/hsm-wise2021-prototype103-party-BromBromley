using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // this script manages all sounds of the game
    // attached to the empty object MusicPlayer
    private AudioSource _soundPlayer;
    [SerializeField] private AudioClip BackgroundMusic;
    [SerializeField] private AudioClip evilLaughter;
    [SerializeField] private AudioClip awwSound;
    [SerializeField] private AudioClip hmmSound;
    [SerializeField] private AudioClip diceRoll;
    [SerializeField] private AudioClip thudSound;
    

    void Awake()
    {
        _soundPlayer = GetComponent<AudioSource>();
    }

    public void StartMusic()
    {
        _soundPlayer.clip = BackgroundMusic;
        _soundPlayer.Play();
    }

    public void DiceSound()
    {
        _soundPlayer.PlayOneShot(diceRoll, 4f);
    }

    public void AngrySound()
    {
        _soundPlayer.PlayOneShot(hmmSound, 1f);
    }

    public void LoseSound()
    {
        _soundPlayer.PlayOneShot(awwSound, 2f);
    }

    public void PlayEvilLaughter()
    {
        _soundPlayer.PlayOneShot(evilLaughter, 3f);
    }

    public void MovingPiece()
    {
        _soundPlayer.PlayOneShot(thudSound, 2f);
    }
}
