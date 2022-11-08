using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public float whenToCreate = 3.0f;
    public float x, y;
    private float timer = 0.0f;
    public Transform player;
    private Camera mainCamera;
    private GameObject enemyObject;
    private Transform enemyTransform;
    private List<GameObject> myObjects;
    void Start()
    {

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myObjects = new List<GameObject>();
    }

    void FixedUpdate()
    {
        x = player.transform.position.x + 25;
        y = player.transform.position.y;
        timer += Time.deltaTime;
        ShouldIDestroy();

        if (timer > whenToCreate)
        {
            enemyObject = Instantiate(enemy[Random.Range(0, 1)], new Vector3(x, y, 0), Quaternion.identity);
            myObjects.Add(enemyObject);
            timer = 0;
            
        }
}
    void ShouldIDestroy()
    {
        for (int i = 0; i < myObjects.Count; i++)
        {
            if(myObjects[i] != null)
            {
                if (myObjects[i].GetComponent<Transform>().position.x < mainCamera.transform.position.x - 12f)
                {
                    Destroy(myObjects[i]);
                    myObjects.Remove(myObjects[i]);
                    
                    
                }
            }
            
            
        }
    }
}
