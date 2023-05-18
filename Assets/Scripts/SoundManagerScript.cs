using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip playerJumpSound, playerHitSound, finishSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        playerJumpSound = Resources.Load<AudioClip>("Jump");
        playerHitSound = Resources.Load<AudioClip>("Explosion");
        finishSound = Resources.Load<AudioClip>("Finish");
        audioSrc = GetComponent<AudioSource>();
	}
	
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "finish":
                audioSrc.PlayOneShot(finishSound);
                break;
        }
    }
}

