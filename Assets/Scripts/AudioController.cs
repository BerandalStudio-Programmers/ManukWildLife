using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider;

    public Slider volumeSliderEffect;

    public GameObject objectMusic;

    private float musicVolume = 0f;

    private AudioSource audioSource;

    public AudioSource[] audioEffect;

    private void Start(){

        objectMusic = GameObject.FindWithTag("Music");
        audioSource = objectMusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;

    }

    private void Update(){
        
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);

    }

    public void VolumeUpdateBGM(float volume){

        musicVolume = volume;

    }

    public void VolumeUpdateEffect(){

        for(int i = 0; i < audioEffect.Length; i++){

            audioEffect[i].volume = volumeSliderEffect.value;

        }

    }

}
