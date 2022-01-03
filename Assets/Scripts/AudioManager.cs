using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour{
	public static AudioManager Instance;
	[SerializeField] private AudioMixerGroup musicMixerGroup;
	[SerializeField] private AudioMixerGroup effectMixerGroup;
	[SerializeField] private Sound[] sounds;
	private void Awake(){
		Instance = this;
		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.audioClip;
			s.source.loop = s.isLoop;
			s.source.volume = s.volume;
			switch(s.audioType){
				case Sound.AudioTypes.effect:
					s.source.outputAudioMixerGroup = effectMixerGroup;
					break;
				
				case Sound.AudioTypes.music:
					s.source.outputAudioMixerGroup = musicMixerGroup;
					break;
			}
			if(s.playOnAwake)
				s.source.Play();
		}
	}
	
	public void Play(string clipname){
		Sound s = Array.Find(sounds, dummySound => dummySound.clipName == clipname);
		if(s==null){
			Debug.LogError("Sound: "+clipname+" does NOT exist!");
		}
		s.source.Stop();
	}
}
