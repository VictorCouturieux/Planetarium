using System;
using System.Collections;
using UnityEngine;

public class CallSoundEvent : MonoBehaviour
{
    public SoundData soundDataFromRedButton;
    public SoundData soundDataFromBlueButton;
    public SoundData soundDataFromGreenButton;
    public SoundData soundDataFromWhiteButton;
    
    public float fadeInDuration = 3.0f;
    public float fadeOutDuration = 3.0f;
    public float crossFadeDuration = 3.0f;

    private AudioSource audioStream;

    void OnEnable()
    {
        Buttons.Button1Pushed += RedButton;
        Buttons.Button2Pushed += BlueButton;
        Buttons.Button3Pushed += GreenButton;
        Buttons.Button4Pushed += WhiteButton;
    }

    private void Update() {
        if (audioStream != null && !audioStream.isPlaying) {
            Destroy(audioStream.gameObject, 0.5f);
            audioStream = null;
        }
    }

    void RedButton() {
        if (audioStream == null) {
            audioStream = SoundEventManager.Instance.play_sound(soundDataFromRedButton, fadeInDuration);
        }
        else if (audioStream.clip != soundDataFromRedButton.current_audio_clip) {
            audioStream = SoundEventManager.Instance.cross_fade_audio_stream(audioStream, soundDataFromRedButton, crossFadeDuration);
        }
        else {
            SoundEventManager.Instance.stop_audio_stream(audioStream, fadeOutDuration);
            audioStream = null;
        }

    }
    
    void BlueButton() {
        if (audioStream == null) {
            audioStream = SoundEventManager.Instance.play_sound(soundDataFromBlueButton, fadeInDuration); 
        }
        else if (audioStream.clip != soundDataFromBlueButton.current_audio_clip) {
            audioStream = SoundEventManager.Instance.cross_fade_audio_stream(audioStream, soundDataFromBlueButton, crossFadeDuration);
        }
        else {
            SoundEventManager.Instance.stop_audio_stream(audioStream, fadeOutDuration);
            audioStream = null;
        }
    }

    void GreenButton() {
        if (audioStream == null) {
            audioStream = SoundEventManager.Instance.play_sound(soundDataFromGreenButton, fadeInDuration);
        }
        else if (audioStream.clip != soundDataFromGreenButton.current_audio_clip) {
            audioStream = SoundEventManager.Instance.cross_fade_audio_stream(audioStream, soundDataFromGreenButton, crossFadeDuration);
        }
        else {
            SoundEventManager.Instance.stop_audio_stream(audioStream, fadeOutDuration);
            audioStream = null;
        }
    }

    void WhiteButton() {
        if (audioStream == null) {
            audioStream = SoundEventManager.Instance.play_sound(soundDataFromWhiteButton, fadeInDuration);
        }
        else if (audioStream.clip != soundDataFromWhiteButton.current_audio_clip) {
            audioStream = SoundEventManager.Instance.cross_fade_audio_stream(audioStream, soundDataFromWhiteButton, crossFadeDuration);
        }
        else {
            SoundEventManager.Instance.stop_audio_stream(audioStream, fadeOutDuration);
            audioStream = null;
        }
    }
}
