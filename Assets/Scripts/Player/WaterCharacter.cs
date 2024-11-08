using UnityEngine;

public class WaterCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] WaterSprayController waterSpray;

    private PlayerState currentState = PlayerState.Idle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
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
        HandleWatering();
    }

    private void HandleWatering()
    {
        if(currentState == PlayerState.Watering) {
            waterSpray.StartWatering();
            waterSpray.transform.position = transform.position;
        } else {
            waterSpray.StopWatering();
        }
    }

    public void OnCharacterSwitch(){
        currentState = PlayerState.Idle;
        HandleWatering();
    }
}
