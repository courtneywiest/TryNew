using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoDamage : MonoBehaviour
{
    [SerializeField] private AudioSource myAudioSource; 
    [SerializeField] private AudioClip myAudioClip9;
    [SerializeField] private float volume = 1.0f;
 
    
    
    

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
		if(collision.gameObject.tag == "Bullet")
		{
			 myAudioSource.PlayOneShot(myAudioClip9, volume);
			//ExecuteAllActions(collision.gameObject);
		}
	}

 
}
