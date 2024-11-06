using System;
using UnityEngine;

public class MemoryOrb : MonoBehaviour
{
    [SerializeField] int indexInLevel; //this should match the index at which it shows in the ui, as well as the index in the list of orbs for each level zone
    public event Action<int> OnOrbPickup = delegate{};
    public bool isPickedUp {get; private set;}

    void Start(){
        isPickedUp = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            OnOrbPickup?.Invoke(indexInLevel);
            isPickedUp = true;
            gameObject.SetActive(false);
        }
    }

    public void ClearEvents(){
        OnOrbPickup = null;
    }
}
