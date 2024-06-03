using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource hoverSound;
    public AudioSource clickSound;

    public AudioSource winPanel;
    public AudioSource losePanel;
    public AudioSource penalty;
    public AudioSource switchMachine;
    public AudioSource mapMachine;

    public void hoverSoundPlay()
    {
        hoverSound.Play();
    }

    public void clickSoundPlay()
    {
        clickSound.Play();
    }

    public void winSoundPlay()
    {
        winPanel.Play();
    }

    public void loseSoundPlay()
    {
        losePanel.Play();
    }

    public void penaltySoundPlay()
    {
        penalty.Play();
    }

    public void penaltySoundStop()
    {
        penalty.Stop();
    }

    public void switchMachineSoundPlay()
    {
        switchMachine.Play();
    }

    public void mapMachineSoundPlay()
    {
        mapMachine.Play();
    }
}
