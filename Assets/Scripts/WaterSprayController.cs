using UnityEngine;

public class WaterSprayController : MonoBehaviour
{
    [SerializeField] ParticleSystem waterPS;
    [SerializeField] Transform player;

    bool isWatering = false;

    void Update()
    {
        if (isWatering) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = ((Vector2)mousePos - (Vector2)player.transform.position).normalized;
            transform.right = dir;
        }
    }

    public void StartWatering(){
        waterPS.Play();
        isWatering = true;
    }

    public void StopWatering(){
        waterPS.Stop();
        isWatering = false;
    }
}
