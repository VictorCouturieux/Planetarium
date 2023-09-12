using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundEventManager : MonoBehaviour
{
    // AudioSource
    public static SoundEventManager instance = null;

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
    
    
}
