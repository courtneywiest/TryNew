using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Create Object")]
[RequireComponent(typeof(Rigidbody2D))]
public class CreateObjectAction : Action
{
	public GameObject prefabToCreate;
	public Vector2 newPosition;
	public bool relativeToThisObject;

	public int resourceIndex = 0;
	private UIScript userInterface;
	public int amount = -1;

	private void Start()
	{
		// Find the UI in the scene and store a reference for later use
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}
		
	// Creates a new GameObject
	public override bool ExecuteAction(GameObject dataObject)
	{
	
		if(prefabToCreate != null)
		{
			//create the new object by copying the prefab
			GameObject newObject = Instantiate<GameObject>(prefabToCreate);
			newObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 420);

			//is the position relative or absolute?
			Vector2 finalPosition = newPosition;
			if (relativeToThisObject)
			{
				finalPosition = (Vector2)transform.position + newPosition;
			}

			//let's place it in the desired position!
			newObject.transform.position = finalPosition;
			return true;
		}
		else
		{
			Debug.LogWarning("There is no Prefab assigned to this CreateObjectAction, so a new object can't be created.");
			return false;
		}
	}

}
