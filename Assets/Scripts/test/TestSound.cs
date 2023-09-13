using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestSound : MonoBehaviour
{
    public SoundData sound;
    private AudioSource source;
    public float duration = 1;

    private void Start() {
    }

    private void Update()
    {
        // Check if the 'Space' key is pressed down.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (source == null) {
                source = SoundEventManager.Instance.play_sound(sound, duration);
            }
            else {
                SoundEventManager.Instance.stop_audio_stream(source, duration);
                source = null;
            }
        }
    }
}
