using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator buttonAnimator; // Animator for the button's arrow animation

    private void Start()
    {
        if (buttonAnimator == null)
        {
            Debug.LogWarning("Animator for button arrow not assigned!");
        }
    }

    // Method to start the game (called by Play button)
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    // Method to quit the game (called by Quit button)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // Just to verify in the editor
    }

    // Highlight button (Show arrow)
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonAnimator != null)
        {
            buttonAnimator.SetTrigger("Highlight");
        }
    }

    // Remove highlight (Hide arrow)
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonAnimator != null)
        {
            buttonAnimator.SetTrigger("Idle");
        }
    }
}