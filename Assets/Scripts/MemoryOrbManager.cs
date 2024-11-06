using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class MemoryOrbManager : MonoBehaviour
{
    public static MemoryOrbManager instance;
    [SerializeField] List<Image> orbSlots;
    [SerializeField] List<LevelZone> levelZones;
    [SerializeField] VolumeProfile volumeProfile;
    int totalOrbs = 0;
    int numOrbsCollected = 0;

    void Start()
    {
        if(instance != null){
            Destroy(this);
        } else {
            instance = this;
        }
        foreach(LevelZone levelZone in levelZones){
            totalOrbs += levelZone.GetNumOrbs();
        }
        OverrideVolumeSaturation();
    }

    void Update()
    {
        
    }

    public void InitiallizeForLevel(List<MemoryOrb> orbs){
        for(int i = 0; i < orbSlots.Count; i++) {
            orbSlots[i].enabled = orbs[i].isPickedUp;
            orbs[i].OnOrbPickup += ToggleOrbSlot;
            orbs[i].OnOrbPickup += UpdateVolumeSaturation;
        }
    }

    void ToggleOrbSlot(int index){
        orbSlots[index].enabled = true;
    }

    void UpdateVolumeSaturation(int index){
        numOrbsCollected++;
        OverrideVolumeSaturation();
    }

    void OverrideVolumeSaturation(){
        if(!volumeProfile.TryGet(out ColorAdjustments colorAdjustments)){
            Debug.Log("[MemoryOrbManager] ERROR: Could not get color adjustment override for global volume profile");
            return;
        }
        colorAdjustments.saturation.Override(Mathf.Lerp(0, -100f, ((float)numOrbsCollected) / totalOrbs));
    }
}
