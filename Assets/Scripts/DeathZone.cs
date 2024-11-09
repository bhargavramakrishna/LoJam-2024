using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] LevelZone levelZone;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(Respawn(col.attachedRigidbody.transform));
        }
    }

    IEnumerator Respawn(Transform player){
        CameraManager.instance.Pause();
        yield return new WaitForSeconds(1f);
        player.position = levelZone.GetRespawnPoint();
        CameraManager.instance.Resume();
    }
}
