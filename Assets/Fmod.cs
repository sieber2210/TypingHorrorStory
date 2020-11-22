using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fmod : MonoBehaviour
{
    FMOD.Studio.EventInstance music;

    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:Music/Music");
        music.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
