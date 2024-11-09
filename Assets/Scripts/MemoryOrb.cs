using System;
using UnityEngine;

public class MemoryOrb : MonoBehaviour
{
    [SerializeField] int indexInLevel; //this should match the index at which it shows in the ui, as well as the index in the list of orbs for each level zone
    [SerializeField] float frequency;
    [SerializeField] float height;
    public event Action<int> OnOrbPickup = delegate{};
    public bool isPickedUp {get; private set;}
    Vector3 startPos;

    void Start(){
        isPickedUp = false;
        startPos = transform.position;
    }

    void Update(){
        transform.position = startPos + height * Mathf.Sin(Time.time * frequency) * Vector3.up;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            OnOrbPickup?.Invoke(indexInLevel);
            isPickedUp = true;
            gameObject.SetActive(false);
            AudioManager.instance.PlayOrbPickup();
        }
    }

    public void ClearEvents(){
        OnOrbPickup = null;
    }
}
