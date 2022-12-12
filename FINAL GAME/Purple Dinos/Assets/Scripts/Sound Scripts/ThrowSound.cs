using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSound : MonoBehaviour
{

    [SerializeField] private AudioSource myAudioSource; 
    [SerializeField] private AudioClip myAudioClip2;
    [SerializeField] private AudioClip myAudioClip3;
    [SerializeField] private float volume = 1.0f;

    private UIScript userInterface;


    // Start is called before the first frame update
    void Start()
    {
        userInterface = GameObject.FindObjectOfType<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAudioSource.PlayOneShot(myAudioClip3, volume);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
            if(userInterface.CheckIfHasResources(0, 1))
            {
                {
                myAudioSource.PlayOneShot(myAudioClip2, volume);
                }
            }
      
    }
}
