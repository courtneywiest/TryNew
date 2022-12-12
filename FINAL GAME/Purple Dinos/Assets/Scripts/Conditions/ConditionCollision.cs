using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Collision")]
[RequireComponent(typeof(Collider2D))]
public class ConditionCollision : ConditionBase
{

	[SerializeField] private AudioSource myAudioSource; 
   // [SerializeField] private AudioClip myAudioClip4;
   

	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, false);
	}
	
	// This function will be called when something touches the trigger collider
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag(filterTag)
			|| !filterByTag)

		{
			ExecuteAllActions(collision.gameObject);
			// myAudioSource.PlayOneShot(myAudioClip4);
			
			//StartCoroutine(Delayed());
		}
		

	//IEnumerator Delayed()
	//{
	//	yield return new WaitForSeconds(2.0f);
	//	ExecuteAllActions(collision.gameObject);
	//}
	//}

	
}
}