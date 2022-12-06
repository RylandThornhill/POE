using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenTimer : MonoBehaviour
{

    public AudioClip prefabSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            audioSource.PlayOneShot(prefabSound, 1F);
        }
    }
}
