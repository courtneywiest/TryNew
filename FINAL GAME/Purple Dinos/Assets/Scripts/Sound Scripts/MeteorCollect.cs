using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollect : MonoBehaviour
{

    [SerializeField] private AudioSource myAudioSource; 
    [SerializeField] private AudioClip myAudioClip7;
    [SerializeField] private float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// is the other object a player?
		if(otherCollider.CompareTag("Player")
			|| otherCollider.CompareTag("Player2"))
		{
			Debug.Log("playerhit");
		
			myAudioSource.PlayOneShot(myAudioClip7, volume);

			Destroy(gameObject);
		}
	}

}
