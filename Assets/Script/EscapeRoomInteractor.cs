using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeRoomInteractor : MonoBehaviour
{
    private int solved = 0;
    public TMPro.TextMeshProUGUI hint;
    public GameObject Title;
    public GameObject Information;
    public GameObject Hint;
    public GameObject Success;
    public GameObject Failure;
    public GameObject Locomotion;
    public AudioClip win;
    public AudioSource sfx;

    public bool CheckGrabbedObject(string tag)
    {
        if (tag == "Ketupat" && solved == 0)
        {
            Debug.Log("The grabbed object has the 'MyTag' tag!");
            solved++;
            hint.text = "I am a musical instrument that is commonly found in Indonesia, Malaysia, and Singapore. I consist of several bamboo tubes of varying lengths, and when struck, I produce a unique sound. What am I?";
            return true;
        }
        else if (tag == "Angklung" && solved == 1)
        {
            solved++;
            hint.text = "I am a traditional Malay dress that is commonly worn by women during festive occasions. I am often brightly colored and feature intricate embroidery. What am I?";
            return true;
        }
        else if (tag == "BajuKurung" && solved == 2)
        {
            solved++;
            hint.text = "I am a traditional Malaysian board game that is played using a wooden board and small stones or shells. The objective of the game is to capture as many pieces as possible from your opponent. What am I?";
            return true;
        }
        else if (tag == "Congkak" && solved == 3)
        {
            Title.SetActive(false);
            Information.SetActive(false);
            Hint.SetActive(false);
            Success.SetActive(true);
            Locomotion.SetActive(false);
            sfx.clip = win;
            sfx.Play();
            RedirectUserAfterSeconds(5);

            return false;
        }
        return false;
    }

    IEnumerator RedirectUserAfterSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //TODO: Uncomment and change to return scene
        //SceneManager.LoadScene(MainMenu);
    }

}
