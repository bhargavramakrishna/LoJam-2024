using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] Transform cameraTarget;
    bool isFollowing;
    Vector3 storedPos;
    Transform storedParent;

    void Awake(){
        if(instance != null){
            Destroy(this);
        } else {
            instance = this;
        }
    }
    
    public void UpdateCameraTarget(Vector3 newPos) {
        if(isFollowing) {
            storedPos = newPos;
        } else {
            cameraTarget.SetParent(null);
            cameraTarget.position = newPos;
        }
    }

    public void UpdateCameraFollowTarget(Transform target) {
        cameraTarget.SetParent(target);
        cameraTarget.localPosition = Vector3.zero;
        isFollowing = true;
    }

    public void StopFollowing(){
        isFollowing = false;
        cameraTarget.SetParent(null);
        cameraTarget.position = storedPos;
    }

    public void Pause(){
        storedParent = cameraTarget.parent;
        cameraTarget.SetParent(null);
    }

    public void Resume(){
        if(storedParent == null) {
            Debug.Log("[CameraManager] Resume: storedParent is null, make sure to call pause first");
            return;
        }
        cameraTarget.SetParent(storedParent);
        cameraTarget.localPosition = Vector3.zero;
    }
}
