using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;// new AudioSource[2];
    void Start()
    {
         music = GameObject.FindWithTag("SONG").GetComponent <AudioSource>();
        // music.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void ToggleSound(bool on){
        if(on)
            music.Play(0);
        else 
            music.Stop();
        
    }
}
