using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBehaviour : MonoBehaviour
{
    private AudioSource music;
    [SerializeField]
    private AudioLevel audioLevel;

    private void Start() {
        music = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        music.volume = audioLevel.volume;
    }
}
