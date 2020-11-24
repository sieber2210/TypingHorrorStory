using UnityEngine;

public class Failure : MonoBehaviour
{
    Animator anim;

    FMOD.Studio.EventInstance failSound;

    private void Start()
    {
        anim = GetComponent<Animator>();        
    }

    public void FailedSentence()
    {
        anim.SetTrigger("Fail");
        failSound = FMODUnity.RuntimeManager.CreateInstance("event:/Damage/Damage");
        failSound.start();
        //sound.setParameterByName("DamageMeter", 1);
        //sound.setVolume(-1000f);
    }
}
