using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip attack, jump, hit,swordswing, energywave,roar,laugh;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        attack = Resources.Load<AudioClip>("attack");
        hit= Resources.Load<AudioClip>("hit");
        swordswing = Resources.Load<AudioClip>("swordswing");
        energywave = Resources.Load<AudioClip>("energywave");
        roar = Resources.Load<AudioClip>("roar");
        laugh = Resources.Load<AudioClip>("laugh");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "fire":
                audioSrc.PlayOneShot(attack);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "swordswing":
                audioSrc.PlayOneShot(swordswing);
                break;
            case "energywave":
                audioSrc.PlayOneShot(energywave);
                break;
            case "roar":
                audioSrc.PlayOneShot(roar);
                break;
            case "laugh":
                audioSrc.PlayOneShot(laugh);
                break;
        }

    }
}
