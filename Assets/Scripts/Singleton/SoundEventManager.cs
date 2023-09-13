using System;
using UnityEngine;
using System.Threading.Tasks;

public class SoundEventManager : MonoBehaviour
{
    // AudioSource
    public static SoundEventManager instance = null;
    
    public GameObject nonSpatializedAudioSourcePrefab;

    public static SoundEventManager Instance
    {
        get
        {
            if (instance == null)
            {
                // If the instance is null, try to find an existing GameManager in the scene.
                instance = FindObjectOfType<SoundEventManager>();

                // If no GameManager exists, create a new GameObject with GameManager component.
                if (instance == null)
                {
                    GameObject gameManagerObject = new GameObject("SoundEventManager");
                    instance = gameManagerObject.AddComponent<SoundEventManager>();
                }
            }

            return instance;
        }
    }
    
    void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public AudioSource play_sound(SoundData resources, float fade_duration = 0) {
        // Instantiate the GameObject with the AudioSource component.
        GameObject audioObject = Instantiate(nonSpatializedAudioSourcePrefab, transform);
        // Access the AudioSource component on the instantiated object.
        AudioSource audioSource = audioObject.GetComponent<AudioSource>();
        _init_sound_stream(audioSource, resources, fade_duration);
        return audioSource;
    }

    public void stop_audio_stream(AudioSource audio_stream, float fade_duration = 0) 
    {
        if (audio_stream.isPlaying) {
            if (fade_duration >= 0) {
                FadeOut(audio_stream, fade_duration);
            }
            else {
                Destroy(audio_stream.gameObject, 0.5f); 
                audio_stream.Stop();
            }
        }
    }
    
    public AudioSource cross_fade_audio_stream(AudioSource old_audio_stream, SoundData new_resources, float fade_duration) {
        GameObject newAudioObject = Instantiate(nonSpatializedAudioSourcePrefab, transform) ?? throw new ArgumentNullException("Instantiate(nonSpatializedAudioSourcePrefab, transform)");
        AudioSource newAudioSource = newAudioObject.GetComponent<AudioSource>();
        stop_audio_stream(old_audio_stream, fade_duration);
        _init_sound_stream(newAudioSource, new_resources, fade_duration);
        return newAudioSource;
    }

    public void set_audio_stream_volume_instantly(AudioSource audio_stream, float new_volume) {
        audio_stream.volume = new_volume; //(new_volume * 104.0f) - 80.0f;
    }
    
    public void set_audio_stream_pitch_instantly(AudioSource audio_stream, float new_pitch) {
        audio_stream.volume = new_pitch; //(new_volume * 104.0f) - 80.0f;
    }
    
    
    //////////////////////
    // private methodes //
    //////////////////////
    
    private void _init_sound_stream(AudioSource audio_stream, SoundData resources, float fade_duration) {
        // todo : Tween fade
        
        audio_stream.volume = resources.randomise_volume_db();
        audio_stream.pitch = resources.randomise_pitch_scale();
        audio_stream.clip = resources.randomise_audio_clip();
        
        audio_stream.Play();
        if (fade_duration >= 0) {
            FadeIn(audio_stream, resources, fade_duration); //.GetAwaiter().GetResult();
        }
    }
    
    //todo fade in with "async await" Task ?
    public async void FadeIn(AudioSource audio_stream, SoundData resources, float fade_duration)
    {
        float startVolume = 0f;
        float targetVolume = resources.current_volume_db;
        float currentTime = 0f;

        audio_stream.volume = startVolume;

        while (currentTime < fade_duration)
        {
            if (audio_stream == null) return;
            audio_stream.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / fade_duration);
            currentTime += Time.deltaTime;
            await Task.Yield();
        }

        audio_stream.volume = targetVolume;
    }
    
    public async void FadeOut(AudioSource audio_stream, float fade_duration)
    {
        float startVolume = audio_stream.volume;
        float targetVolume = 0f;
        float currentTime = 0f;

        audio_stream.volume = startVolume;

        while (currentTime < fade_duration)
        {
            audio_stream.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / fade_duration);
            currentTime += Time.deltaTime;
            await Task.Yield();
        }

        audio_stream.volume = 0;
        audio_stream.Stop();
        Destroy(audio_stream.gameObject, 0.5f); 
    }


}
