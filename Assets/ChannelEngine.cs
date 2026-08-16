using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
public class ChannelEngine : MonoBehaviour
{
    public AudioClip SelectedClip;
    public bool looped;
    public float Volume;
    public bool FadeIn;
    public bool FadeOut;

    public AudioSource src;

    public float currentTime;
    public float length;

    public Transform SelectUI;
    public Slider volumeslider;
    public Slider FadeInRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Awake()
    {
        src = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(SelectedClip != null && src.isPlaying == true)
        {
            length = SelectedClip.length;
            currentTime = src.time;
        }
        else
        {
            length = 0;
            currentTime = 0;
        }
    }

    private void OnEnable()
    {
        
    }
    public void SelectAudio(AudioClip clip,Transform button)
    {
        SelectedClip = clip;

        SelectUI.transform.position = button.transform.position;
    }

    public void PlayAudio()
    {
        src.clip = SelectedClip;

        if (FadeIn == true)
        {
            volumeslider.GetComponent<VolumeSlider>().SetEnable(false);
            src.volume = 0;
            src.DOFade(FadeInRange.value, 1).OnComplete(() =>
            {
                volumeslider.GetComponent<VolumeSlider>().SetEnable(true);
            });
        }
        src.Play();
    }

    public void PlayAudioSFX()
    {
        if (FadeIn == true)
        {
            volumeslider.GetComponent<VolumeSlider>().SetEnable(false);
            src.volume = 0;
            src.DOFade(FadeInRange.value, 1).OnComplete(() =>
            {
                volumeslider.GetComponent<VolumeSlider>().SetEnable(true);
            });
        }
        src.PlayOneShot(SelectedClip);
    }

    public void PlayAudioAmb()
    {
        if (FadeIn == true)
        {
            volumeslider.GetComponent<VolumeSlider>().SetEnable(false);
            src.volume = 0;
            src.DOFade(FadeInRange.value, 1).OnComplete(() =>
            {
                volumeslider.GetComponent<VolumeSlider>().SetEnable(true);
            });
        }
        src.Play();
    }
    public void ToggleLoop()
    {
        looped = !looped;
        src.loop = looped;
    }

    public void Toggle(bool Type)
    {
        Type = !Type;
    }
    
    public void Next()
    {
        if (FadeOut == true)
        {
            volumeslider.GetComponent<VolumeSlider>().SetEnable(false);
            src.DOFade(0, 1).OnComplete(() =>
            {
                src.Stop();
                volumeslider.GetComponent<VolumeSlider>().SetEnable(true);
                if (FadeIn == true)
                {
                    volumeslider.GetComponent<VolumeSlider>().SetEnable(false);
                    PlayAudio();
                    src.DOFade(FadeInRange.value, 1).OnComplete(() =>
                    {
                        volumeslider.GetComponent<VolumeSlider>().SetEnable(true);
                    });
                }
                else
                {
                    src.volume = 1;
                    PlayAudio();
                }
            });
        }
        else
        {
            if (FadeIn == true)
            {
                volumeslider.GetComponent<VolumeSlider>().SetEnable(false);
                PlayAudio();
                src.DOFade(FadeInRange.value, 1).OnComplete(() =>
                {
                    volumeslider.GetComponent<VolumeSlider>().SetEnable(true);
                });
            }
            else
            {
                PlayAudio();
            }
        }

        
        

    }


    public void Fade(float target)
    {

            volumeslider.GetComponent<VolumeSlider>().SetEnable(false);
            src.DOFade(target, 1).OnComplete(() =>
            {
                volumeslider.GetComponent<VolumeSlider>().SetEnable(true);
            });

    }
}
