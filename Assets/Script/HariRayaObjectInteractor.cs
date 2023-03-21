using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HariRayaObjectInteractor : MonoBehaviour
{

    public AudioSource sfx;
    private XRGrabInteractable grabInteractable;
    public GameObject gameObject;
    public AudioClip collected;
    public EscapeRoomInteractor escapeRoomInteractor;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        Debug.Log(grabInteractable);
        grabInteractable.onSelectEnter.AddListener(OnSelectEnter);
        sfx.clip = collected;
    }

    void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (gameObject != null)
        {
            Debug.Log(gameObject.tag);
            if (escapeRoomInteractor.CheckGrabbedObject(gameObject.tag))
            {
                gameObject.SetActive(false);
                sfx.Play();
            }
        }
    }

    
}
