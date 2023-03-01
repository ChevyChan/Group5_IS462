using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutScript : MonoBehaviour
{
    public void endScene()
    {
        SceneManager.LoadScene("StartingScene");
    }
}
