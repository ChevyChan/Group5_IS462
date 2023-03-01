using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StatsController : MonoBehaviour
{ 
    public static int startingScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro score = GetComponent<TextMeshPro>();
        score.text = startingScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro score = GetComponent<TextMeshPro>();
        score.text = startingScore.ToString();

        if(startingScore == 5)
        {
            SceneManager.LoadScene("EndTutScene");
        }
    }
}
