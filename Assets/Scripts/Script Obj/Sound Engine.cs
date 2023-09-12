using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum BusType
{
    Master,
    Music
}

[CreateAssetMenu(fileName = "Sound Data", menuName = "Sound/Sound Data")]
public class SoundData : ScriptableObject
{
    public List<AudioClip> sound_stream = new List<AudioClip>();
    
    [Range(-80.0f, 24.0f)] public float min_volume_db = 0.0f ;
    [Range(-80.0f, 24.0f)] public float max_volume_db = 0.0f ;
    
    
    [Range(0.01f, 4.0f)] public float min_pitch_scale = 1.0f  ;
    [Range(0.01f, 4.0f)] public float max_pitch_scale = 1.0f ;
    
    public BusType bus = BusType.Master;

    [HideInInspector] public AudioClip current_audio_clip;
    [HideInInspector] public float current_volume_db = 0.0f;
    [HideInInspector] public float current_pitch_scale = 1.0f;

    [FormerlySerializedAs("_currant_sound_play_list")] [HideInInspector] public int _current_sound_play_list = 0;

    public SoundData() {
        if (sound_stream.Count != 0) {
            current_audio_clip = sound_stream[0];
        }
    }
    
    public AudioClip read_next_one_audio_clip() {
        _current_sound_play_list++;
        if (_current_sound_play_list >= sound_stream.Count) 
            _current_sound_play_list = 0;
        current_audio_clip = sound_stream[_current_sound_play_list];
        return current_audio_clip;
    }

    public AudioClip randomise_audio_clip() {
        _current_sound_play_list = Random.Range(0, sound_stream.Count) ;
        current_audio_clip = sound_stream[_current_sound_play_list];
        return current_audio_clip;
    }

    public float randomise_volume_db() {
        current_volume_db = Random.Range(min_volume_db, max_volume_db);
        return current_volume_db;
    }

    public float randomise_pitch_scale() {
        current_pitch_scale = Random.Range(min_pitch_scale, max_pitch_scale);
        return current_pitch_scale;
    }

    
    
}


