using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    public GameObject Character1;
    public GameObject Character2;

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
            }
            else
            {
                Character1.SetActive(true);
                Character1.transform.position = Character2.transform.position;
                Character2.SetActive(false);
                characterOn = true;
            }
            
        }
    }
}
