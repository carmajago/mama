using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ssounds : MonoBehaviour
{

    public AudioClip[] clips;

    private AudioSource player;

    void Start()
    {
        player = GetComponent<AudioSource>();
        player.clip = clips[0]; 
    }
    public void paso1()
    {
        player.clip = clips[1];
        player.Play();
    }    
    public void paso2()
    {
        player.clip = clips[2];
        player.Play();
    }
    public void paso3()
    {
        player.clip = clips[3];
        player.Play();
    }
    public void paso4()
    {
        player.clip = clips[4];
        player.Play();
    }
    public void paso5()
    {
        player.clip = clips[5];
        player.Play();
    }

}


