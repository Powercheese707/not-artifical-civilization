using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostalMan : MonoBehaviour
{
    private Transform target;
    private GameCode gamecode;

    public float price = 50f;
    // Start is called before the first frame update
    void Start()
    {

        gamecode = gamecode = GameObject.Find("Canvas").GetComponent<GameCode>();


        string tagName = "Building";

        GameObject[] taggedGameObjects = GameObject.FindGameObjectsWithTag(tagName);

        Transform[] transformsArray = new Transform[taggedGameObjects.Length];
        for (int i = 0; i < taggedGameObjects.Length; i++)
        {
            transformsArray[i] = taggedGameObjects[i].transform;
        }

        List<Transform> transformsList = new List<Transform>();
        foreach (GameObject obj in taggedGameObjects)
        {
            if (obj.name != "BugCollider") {
                transformsList.Add(obj.transform);
            }
        }
        
        target = transformsList[Random.Range(0, transformsList.Count)];
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            gamecode.gold = gamecode.gold + price + gamecode.postOfficeUpgraded;
            Destroy(gameObject);
        }
    }
    
}
