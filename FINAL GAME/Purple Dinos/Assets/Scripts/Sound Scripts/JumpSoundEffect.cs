using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundEffect : MonoBehaviour
{

    [SerializeField] private AudioSource myAudioSource; 
    [SerializeField] private AudioClip myAudioClip1;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAudioSource.PlayOneShot(myAudioClip1);
        }
    }
}
