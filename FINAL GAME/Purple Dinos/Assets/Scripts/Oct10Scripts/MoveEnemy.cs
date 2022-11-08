using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public enum direction
    {
        Vertical,
        Horizontal
    };

    private Rigidbody2D rgb;
    private float timer = 0.0f;
    public direction whichDirection;
    public int speed = 2;
    private SpriteRenderer sprt;
    // Start is called before the first frame update
    void Start()
    {
        //whichDirection = direction.Vertical;
        rgb = GetComponent<Rigidbody2D>();
        sprt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        if(timer > 3)
        {
            speed *= -1;
            timer = 0.0f;
        }
        if(whichDirection == direction.Vertical)
        {
            rgb.velocity = new Vector3(0, speed, 0);
        }
        else if(whichDirection == direction.Horizontal)
        {
            rgb.velocity = new Vector3(speed, 0, 0);
        }
        if(speed < 0)
        {
            sprt.flipX = false;
            //Debug.Log("left");
        }
        else if (speed > 0)
        {
            sprt.flipX = true;
            //Debug.Log("right");
        }
        

    }
}
