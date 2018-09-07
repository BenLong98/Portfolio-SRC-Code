using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicVolume : MonoBehaviour {

    public Slider Volume;
    public AudioSource music;

     void Awake()
    {
        music.volume = .5f;
        music.Play();
    }
    void Update()
    {
        
        Volume = Slider.FindObjectOfType<Slider>();
        music.volume = Volume.value;
    }

}
