using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] GameObject gameEndOverlay;
    [SerializeField] Image background;
    [SerializeField] TMP_Text endText;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] EndingDoor endTrigger;
    bool isGameEnded = false;

    void Start(){
        quitButton.SetActive(false);
        restartButton.SetActive(false);
        endTrigger.EndGame += EndGame;
        gameEndOverlay.SetActive(false);
    }

    void EndGame(){
        if(!isGameEnded){
            isGameEnded = true;
            gameEndOverlay.SetActive(true);
            StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd(){
        float timer = 0;
        float duration = 1f;
        while(timer < duration) {
            background.color = new Color(0, 0, 0, Mathf.Lerp(0, 0.5f, timer/duration));
            endText.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, timer/duration));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        quitButton.SetActive(true);
        restartButton.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit(){
        Application.Quit();
    }
}
