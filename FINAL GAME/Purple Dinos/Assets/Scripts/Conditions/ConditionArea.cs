using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Area")]
public class ConditionArea : ConditionBase
{
	// the amount of times (in seconds) that this Condition will call OnTriggerStay
	// i.e. if it's 1, it means that OnTriggerStay will be called every second
	// i.e. if it's 4, it means that it will be called every 4 seconds
	// ... and so on...
	public float frequency = 1f;
	//not used in case of ColliderEventTypes.Enter and ColliderEventTypes.Exit


	//the type of event to check for
	[Header("Type of Event")]
	public ColliderEventTypes eventType = ColliderEventTypes.Enter;

	[SerializeField] private AudioSource myAudioSource; 
   	//[SerializeField] private AudioClip myAudioClip4;	

	private float lastTimeTriggerStayCalled;


	// This function will be called at the beginning
	void Start()
	{
		lastTimeTriggerStayCalled = -frequency;
	}


	//This will create a dialog window asking for which dialog to add
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}
	
	
	

	//this function is called every time another collider enters this trigger
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		//is this the type of event we need?
		if(eventType == ColliderEventTypes.Enter)
		{

			//check for the tag of the object which entered the area, if necessary
			if(otherCollider.CompareTag(filterTag)
				|| !filterByTag)
			{
				//myAudioSource.Play();
				StartCoroutine(Delayed());
				//ExecuteAllActions(otherCollider.gameObject);
			}
			IEnumerator Delayed()
			{
				yield return new WaitForSeconds(2.5f);
				ExecuteAllActions(gameObject);
			}
		}
	}



	



	public enum ColliderEventTypes
	{
		Enter,
	}}




