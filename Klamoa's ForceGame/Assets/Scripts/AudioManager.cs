using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

	public AudioMixer audioMixer;

	public Sound[] sounds;

	public static AudioManager instance;


	void Awake() {

		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.outputAudioMixerGroup = s.mixerGroup;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Start () {

		// Set the volume to the volume last session
		audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("_volume"));

		// Play MainTheme at the start
		Play ("MainTheme");
	}

	// Use anywhere in code to play a sound	
	public void Play (string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();
	}

	// Volumeslider code
	public void Volume (float volume) {
		audioMixer.SetFloat("volume", volume);
		PlayerPrefs.SetFloat("_volume", volume);
	}
}
