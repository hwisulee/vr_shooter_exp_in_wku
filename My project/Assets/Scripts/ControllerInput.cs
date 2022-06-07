using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerInput : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;
    public Transform gunTransform;
    public TargetScript targetScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            audioSource.Play();
            RaycastGun();
        }
    }

    private void RaycastGun()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunTransform.position, gunTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Target"))
            {
                targetScript.isHit = true;
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
