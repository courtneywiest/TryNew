using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("")]
public class UIScript : MonoBehaviour
{
	[Header("Configuration")]
	public Players numberOfPlayers = Players.OnePlayer;

	public GameType gameType = GameType.Score;

	// If the scoreToWin is -1, the game becomes endless (no win conditions, but you could do game over)
	public int scoreToWin = 1;

	public int addHealth = 1;



	[Header("References (don't touch)")]
	//Right is used for the score in P1 games
	public Text[] numberLabels = new Text[2];
	public Text rightLabel, leftLabel;
	public Text winLabel;
	public GameObject statsPanel, gameOverPanel, winPanel;
	public Transform inventory;
	public GameObject resourceItemPrefab;


	// Internal variables to keep track of score, health, and resources, win state
	private int[] scores = new int[2];
	private int[] playersHealth = new int[2];
	public Dictionary<int, ResourceStruct> resourcesDict = new Dictionary<int, ResourceStruct>(); //holds a reference to all the resources collected, and to their UI
    private bool gameOver = false; //this gets changed when the game is won OR lost


	private void Start()
	{
		if(numberOfPlayers == Players.OnePlayer)
		{
			// No setup needed
		}
		else
		{
			if(gameType == GameType.Score)
			{
				// Show the 2-player score interface
				rightLabel.text = leftLabel.text = "Score";

				// Show the score as 0 for both players
				numberLabels[0].text = numberLabels[1].text = "0";
				scores[0] = scores[1] = 0;
			}
			else
			{
				// Show the 2-player life interface
				rightLabel.text = leftLabel.text = "Life";

				// Life will be provided by the PlayerHealth components
			}
		}
	}

	//version of the one below with one parameter to be able to connect UnityEvents
	public void AddOnePoint(int playerNumber)
	{
		AddPoints(playerNumber, 1);
	}



	public void AddPoints(int playerNumber, int amount = 1)
	{
		scores[playerNumber] += amount;

		if(numberOfPlayers == Players.OnePlayer)
		{
			numberLabels[1].text = scores[playerNumber].ToString(); //with one player, the score is on the right
		}
		else
		{
			numberLabels[playerNumber].text = scores[playerNumber].ToString();
		}

		if(gameType == GameType.Score
			&& scores[playerNumber] >= scoreToWin)
		{
			Debug.Log("gamewin");
			ResetCoins();
			SetHealth(playersHealth[playerNumber] + 1, playerNumber);
		
			
			//playersHealth[playerNumber] --;
			//GameWon(playerNumber);
		}
	}

	//currently unused by other Playground scripts
	public void RemoveOnePoint(int playerNumber)
	{
		scores[playerNumber]--;

		if(numberOfPlayers == Players.OnePlayer)
		{
			numberLabels[1].text = scores[playerNumber].ToString(); //with one player, the score is on the right
		}
		else
		{
			numberLabels[playerNumber].text = scores[playerNumber].ToString();
		}
	}


  








	public void ResetCoins()
	{
		numberLabels[1].text = "0";
				scores[0] = scores[1] = 0;
	}




//COLLECT COINS TO "WIN" - ADD TO HEALTH INSTEAD AND RESET 
	














	public void GameOver(int playerNumber)
	{
        // only set game over UI if game is not over
	    if (!gameOver)
	    {
			gameOver = true;
	        statsPanel.SetActive(false);
	        gameOverPanel.SetActive(true);
	    }
	}



	public void SetHealth(int amount, int playerNumber)
	{
		playersHealth[playerNumber] = amount;
		numberLabels[playerNumber].text = playersHealth[playerNumber].ToString();
	}



	public void ChangeHealth(int change, int playerNumber)
	{
		SetHealth(playersHealth[playerNumber] + change, playerNumber);

	}











 




















	//Adds a resource to the dictionary, and to the UI
	public void AddResource(int resourceType, int pickedUpAmount, Sprite graphics)
	{
		if(resourcesDict.ContainsKey(resourceType))
		{
			//update the dictionary key
			int newAmount = resourcesDict[resourceType].amount + pickedUpAmount;
			resourcesDict[resourceType].UIItem.ShowNumber(newAmount);
			resourcesDict[resourceType].amount = newAmount;
		} 


		else
		{
			//create the UIItemScript and display the icon
			UIItemScript newUIItem = Instantiate<GameObject>(resourceItemPrefab).GetComponent<UIItemScript>();
			newUIItem.transform.SetParent(inventory, false);

			resourcesDict.Add(resourceType, new ResourceStruct(pickedUpAmount, newUIItem));

			resourcesDict[resourceType].UIItem.ShowNumber(pickedUpAmount);
			resourcesDict[resourceType].UIItem.DisplayIcon(graphics);
		}
	}










	//[SerializeField] private AudioSource myAudioSource; 
   // [SerializeField] private AudioClip myAudioClip1;
	//[SerializeField] private AudioClip myAudioClip4;




	

	public int amountNeeded = 1;


	public KeyCode keyToPress = KeyCode.Tab;


	//checks if a certain resource is in the inventory, in the needed quantity
	public bool CheckIfHasResources(int resourceType, int amountNeeded = 1)
	{  
		
		if(resourcesDict.ContainsKey(resourceType))
		{
			if(Input.GetKeyDown(keyToPress) && resourcesDict[resourceType].amount >= amountNeeded)
			{
				//myAudioSource.PlayOneShot(myAudioClip4);
				
				//ExecuteAllActions(null);
				Debug.Log("gotemmmmmmmmmmmmmm");
				return true;
				
			}
			else
			{
				//ExecuteAllActions(null);
				//not enough
				//Debug.Log("notenought");
				//myAudioSource.PlayOneShot(myAudioClip2);
				return false;

			
				
				
			}
		}
		
		{
			//resource not present
		
			return false;
		}
	}















	//to use only before checking that the resource is in the dictionary
	public void ConsumeResource(int resourceType, int amountNeeded = 1)
	{
		resourcesDict[resourceType].amount -= amountNeeded;
		resourcesDict[resourceType].UIItem.ShowNumber(resourcesDict[resourceType].amount);
	}


	public enum Players
	{
		OnePlayer = 0,
		TwoPlayers
	}

	public enum GameType
	{
		Score = 0,
		Life,
		Endless
	}
}














//just a virtual representation of the resources for the private dictionary
public class ResourceStruct
{
	public int amount;
	public UIItemScript UIItem;

	public ResourceStruct(int a, UIItemScript uiRef)
	{
		amount = a;
		UIItem = uiRef;
	}
}