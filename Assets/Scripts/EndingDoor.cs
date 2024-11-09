using Unity.VisualScripting;
using UnityEngine;

public class EndingDoor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Player has reached the end of the level");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
