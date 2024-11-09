using System;
using UnityEngine;

public class EndingDoor : MonoBehaviour
{   
    public event Action EndGame = delegate{};
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            EndGame();
        }
    }
}
