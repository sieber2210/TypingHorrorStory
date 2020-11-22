using UnityEngine;

public class Failure : MonoBehaviour
{
    Animator anim;

    //FMOD.Studio.EventInstance sound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //sound = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Music");
        //sound.start();
    }

    public void FailedSentence()
    {
        anim.SetTrigger("Fail");
        //sound.setParameterByName("DamageMeter", 1);
        //sound.setVolume(-1000f);
    }
}
