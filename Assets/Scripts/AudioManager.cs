using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour{
	public static AudioManager Instance;
	[SerializeField] private AudioMixerGroup menuMusicMixerGroup;
	[SerializeField] private AudioMixerGroup gameplayMusicMixerGroup;
	[SerializeField] private AudioMixerGroup walkingEffectMixerGroup;
	[SerializeField] private AudioMixerGroup clickEffectMixerGroup;
	[SerializeField] private AudioMixerGroup lompatEffectMixerGroup;
	[SerializeField] private AudioMixerGroup nangisEffectMixerGroup;
	[SerializeField] private AudioMixerGroup hideEffectMixerGroup;
	[SerializeField] private AudioMixerGroup matiEffectMixerGroup;
	[SerializeField] private AudioMixerGroup tembakEffectMixerGroup;
	[SerializeField] private AudioMixerGroup burungEffectMixerGroup;
	[SerializeField] private AudioMixerGroup missionSucceedEffectMixerGroup;
	[SerializeField] private Sound[] sounds;
	private void Awake(){
		Instance = this;
		foreach(Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.audioClip;
			s.source.loop = s.isLoop;
			s.source.volume = s.volume;
			switch(s.audioType){
				case Sound.AudioTypes.walkingEffect:
					s.source.outputAudioMixerGroup = walkingEffectMixerGroup;
					break;
				case Sound.AudioTypes.clickEffect:
					s.source.outputAudioMixerGroup = clickEffectMixerGroup;
					break;
				case Sound.AudioTypes.lompatEffect:
					s.source.outputAudioMixerGroup = lompatEffectMixerGroup;
					break;
				case Sound.AudioTypes.nangisEffect:
					s.source.outputAudioMixerGroup = nangisEffectMixerGroup;
					break;
				case Sound.AudioTypes.hideEffect:
					s.source.outputAudioMixerGroup = hideEffectMixerGroup;
					break;
				case Sound.AudioTypes.matiEffect:
					s.source.outputAudioMixerGroup = matiEffectMixerGroup;
					break;
				case Sound.AudioTypes.burungEffect:
					s.source.outputAudioMixerGroup = burungEffectMixerGroup;
					break;
				case Sound.AudioTypes.missionSucceedEffect:
					s.source.outputAudioMixerGroup = missionSucceedEffectMixerGroup;
					break;
				case Sound.AudioTypes.menuMusic:
					s.source.outputAudioMixerGroup = menuMusicMixerGroup;
					break;
				case Sound.AudioTypes.gameplayMusic:
					s.source.outputAudioMixerGroup = gameplayMusicMixerGroup;
					break;
				case Sound.AudioTypes.tembakEffect:
					s.source.outputAudioMixerGroup = tembakEffectMixerGroup;
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
