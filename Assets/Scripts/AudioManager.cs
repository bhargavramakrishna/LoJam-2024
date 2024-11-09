using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource footstep;
    [SerializeField] AudioSource waterbgm;
    [SerializeField] AudioSource wateringSound;
    [SerializeField] AudioSource button;
    [SerializeField] AudioSource orbPickup;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource mushroomGrow;
    public static AudioManager instance;

    void Awake(){
        if(instance != null) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    public void PlayFootstep(){
        footstep.Play();
    }

    public void ToggleWaterBGM(bool toggle){
        if(toggle){
            waterbgm.Play();
        } else {
            waterbgm.Pause();
        }
    }

    public void ToggleWateringSound(bool toggle){
        if(toggle){
            if(!wateringSound.isPlaying){
                wateringSound.Play();
            }
        } else {
            wateringSound.Pause();
        }
    }

    public void PlayButton(){
        button.Play();
    }

    public void PlayMushroomGrow(){
        mushroomGrow.Play();
    }

    public void PlayOrbPickup(){
        orbPickup.Play();
    }

    public void PlayJump(){
        jump.Play();
    }

}
