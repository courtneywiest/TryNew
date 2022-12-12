using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{

	[SerializeField] private AudioSource myAudioSource; 
    [SerializeField] private AudioClip myAudioClip4;
   

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, false);
	}
	
	// This function will be called when something touches the trigger collider
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.gameObject.tag == "Player")
			
		{
			Debug.Log("touched");
			myAudioSource.PlayOneShot(myAudioClip4);
			//StartCoroutine(Delayed());
			//ExecuteAllActions(collision.gameObject);
		}

	//IEnumerator Delayed()
	{
	//	yield return new WaitForSeconds(2.0f);
	//	ExecuteAllActions(collision.gameObject);
	//}
	//}
	}
}
}