using UnityEngine;

public class WaterCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;

    private PlayerState currentState = PlayerState.Idle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentState = PlayerState.Watering;
        }
        else
        {
            currentState = PlayerState.Idle;
        }

        animator.SetInteger("State", (int)currentState);
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Watering:
                HandleWatering();
                break;
        }
    }

    private void HandleWatering()
    {
        // Water the plant
    }
}
