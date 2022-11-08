using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgb;
    public int speed = 5;
    float x = 0.0f;
    float y = 0.0f;
    public int Health = 5;
    
    //private TMP_Text myText; // we can update the text directly
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        // if we change the text directly we can get it here
        //myText = GameObject.Find("MainText").GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rgb.velocity = new Vector3(x * speed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            // as long as we hit an enemy, then, we can get what their damage is
            // we access the damage script in the enemy
            Damage myDamage = collision.gameObject.GetComponent<Damage>();
            // get the damage property in the damage script
            int whatIsTheDamage = myDamage.damage;
            // decrease the damage
            Health -= whatIsTheDamage;
            // access the score manager script that is in the empty object
            ScoreChanger myManager = GameObject.Find("HUDManager").GetComponent<ScoreChanger>();
            // call the function that is in that script
            myManager.changeHealth(Health);
            // remove the object that the player collided with
            Destroy(collision.gameObject);
            // update the text component here
            // myText.text = "Health: " + Health;
            //Debug.Log(whatIsTheDamage);
        }

        else if(collision.gameObject.CompareTag("Coin"))
        {
            Damage myDamage = collision.gameObject.GetComponent<Damage>();
            // get the damage property in the damage script
            int whatIsTheDamage = myDamage.damage;
            // decrease the damage
            Health -= whatIsTheDamage;
            // access the score manager script that is in the empty object
            ScoreChanger myManager = GameObject.Find("HUDManager").GetComponent<ScoreChanger>();
            // call the function that is in that script
            myManager.changeHealth(Health);
            // remove the object that the player collided with
            Destroy(collision.gameObject);
        }
    }
}
