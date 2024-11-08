using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] Transform cameraTarget;

    void Start(){
        if(instance != null){
            Destroy(this);
        } else {
            instance = this;
        }
    }
    public void UpdateCameraTarget(Vector3 newPos) {
        cameraTarget.SetParent(null);
        cameraTarget.position = newPos;
    }

    public void UpdateCameraFollowTarget(Transform target) {
        cameraTarget.SetParent(target);
        cameraTarget.localPosition = Vector3.zero;
    }
}
