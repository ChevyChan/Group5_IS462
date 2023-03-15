using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour
{

    public AudioSource sfxAudioSource;
    public AudioClip activationClip;
    private animationStateController Monster;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        Monster = GameObject.FindObjectOfType<animationStateController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sfxAudioSource.clip = activationClip;
            sfxAudioSource.Play();
            Monster.Stun();
            gameObject.SetActive(false);
        }

    }
}
