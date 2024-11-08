using UnityEngine;

public class CameraPlayerFollowTrigger : MonoBehaviour
{
    [SerializeField] LevelZone levelZone;
    [SerializeField] bool followPlayer;
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            if(followPlayer){
                CameraManager.instance.UpdateCameraFollowTarget(col.transform);
            } else {
                CameraManager.instance.UpdateCameraTarget(levelZone.GetCameraCenter());
            }
        }
    }
}
