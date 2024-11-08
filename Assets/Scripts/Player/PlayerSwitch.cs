using System.Collections;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject Character1;
    public GameObject Character2;
    [SerializeField] SpriteRenderer distortionMask;
    [SerializeField] float distortionMaxBlend;

    private bool characterOn = true;

    // Update is called once per frame
    void Update()
    {
        HandleForm();
    }
    private void HandleForm()
    {
        if (Input.GetKeyDown(KeyCode.E) )
        {
           
            if (characterOn == true)
            {
                Character2.SetActive(true);
                
                Character2.transform.position = Character1.transform.position;
                Character1.SetActive(false);
                characterOn = false;
                StartCoroutine(DistortionBlendIn());
            }
            else
            {
                Character1.SetActive(true);
                Character1.transform.position = Character2.transform.position;
                Character2.SetActive(false);
                characterOn = true;
                StartCoroutine(DistortionBlendOut());
                Character2.GetComponent<WaterCharacter>().OnCharacterSwitch();
            }
        }
    }

    IEnumerator DistortionBlendIn(){
        float timer = 0;
        float duration = 0.5f;
        Material mat = distortionMask.material;
        while(timer < duration) {
            mat.SetFloat("_Blend", Mathf.Lerp(0, distortionMaxBlend, timer/duration));
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator DistortionBlendOut(){
        float timer = 0;
        float duration = 0.5f;
        Material mat = distortionMask.material;
        while(timer < duration) {
            mat.SetFloat("_Blend", Mathf.Lerp(distortionMaxBlend, 0, timer/duration));
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
