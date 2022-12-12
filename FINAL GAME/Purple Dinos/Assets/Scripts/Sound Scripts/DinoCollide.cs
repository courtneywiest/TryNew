using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCollide : MonoBehaviour
{

    [SerializeField] private AudioSource myAudioSource; 
    [SerializeField] private AudioClip myAudioClip2;
    [SerializeField] private AudioClip myAudioClip3;
    [SerializeField] private AudioClip myAudioClip4;
    [SerializeField] private float volume1 = 1.0f;
    [SerializeField] private float volume2 = 1.0f;
    [SerializeField] private float volume3 = 1.0f;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			 myAudioSource.PlayOneShot(myAudioClip2, volume2);
			//ExecuteAllActions(collision.gameObject);
		}

        if(collision.gameObject.tag == "Finish")
        {
            myAudioSource.PlayOneShot(myAudioClip3, volume3);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            myAudioSource.PlayOneShot(myAudioClip4, volume1);
        }
	}

 
}
