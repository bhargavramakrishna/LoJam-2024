using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelZone : MonoBehaviour
{
    [SerializeField] Transform cameraCenter;
    [SerializeField] List<MemoryOrb> orbs;

    void Start(){

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            CameraManager.instance.UpdateCameraTarget(cameraCenter.position);
            MemoryOrbManager.instance.InitiallizeForLevel(orbs);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.CompareTag("Player")){
            foreach(MemoryOrb orb in orbs) {
                orb.ClearEvents();
            }
        }
    }

    public int GetNumOrbs(){
        return orbs.Count;
    }

    public Vector3 GetCameraCenter(){
        return cameraCenter.position;
    }
}
