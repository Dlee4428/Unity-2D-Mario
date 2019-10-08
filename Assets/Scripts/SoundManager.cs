using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip stompSound, jumpSmallSound, jumpBigSound, deathSound, mushroomSound,
        coinSound, bumpSound, gameoverSound, powerupSound, background, stageClear;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

        stompSound = Resources.Load<AudioClip>("SoundEffects/stomp");
        jumpSmallSound = Resources.Load<AudioClip>("SoundEffects/jumpSmall");
        jumpBigSound = Resources.Load<AudioClip>("SoundEffects/jumpBig");
        deathSound = Resources.Load<AudioClip>("SoundEffects/death");
        mushroomSound = Resources.Load<AudioClip>("SoundEffects/mushroom");
        powerupSound = Resources.Load<AudioClip>("SoundEffects/powerup");
        bumpSound = Resources.Load<AudioClip>("SoundEffects/bump");
        coinSound = Resources.Load<AudioClip>("SoundEffects/coin");
        gameoverSound = Resources.Load<AudioClip>("SoundEffects/gameover");
        background = Resources.Load<AudioClip>("SoundEffects/background");
        stageClear = Resources.Load<AudioClip>("SoundEffects/stageClear");

        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip){
            case "stomp":
                audioSrc.PlayOneShot(stompSound);
                break;
            case "jumpSmall":
                audioSrc.PlayOneShot(jumpSmallSound);
                break;
            case "jumpBig":
                audioSrc.PlayOneShot(jumpBigSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "mushroom":
                audioSrc.PlayOneShot(mushroomSound);
                break;
            case "powerup":
                audioSrc.PlayOneShot(powerupSound);
                break;
            case "bump":
                audioSrc.PlayOneShot(bumpSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "gameover":
                audioSrc.PlayOneShot(gameoverSound);
                break;
            case "stageClear":
                audioSrc.PlayOneShot(stageClear);
                break;
        }
    }

    public static void StopSound (string clip)
    {
        switch (clip){
            case "background":
                audioSrc.Stop();
                break;
        }
    }
}
