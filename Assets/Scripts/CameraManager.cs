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
    public void UpdateCameraTarget(Vector3 newPos){
        cameraTarget.position = newPos;
    }
}
