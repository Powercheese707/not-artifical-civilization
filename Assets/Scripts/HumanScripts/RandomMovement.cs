using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 1f;
    public GameObject center;
    public float maxDistance = 20f;


    private float lengthMove = 70f;
    private float count = 0f;
    private bool moving = false;
    private Vector3 direction = new Vector3(0, 0 , 0);


    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.Find("Center");

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, center.transform.position);
        if (!moving && distance <= maxDistance) {

            if (Random.Range(0, 150) == 1) {
                
                lengthMove = Random.Range(100, 200);
                count = 0f;
                moving = true;
                direction = new Vector3(Random.Range(-4, 4) * speed, Random.Range(-4, 4)* speed, 0);

            }

        } else if (count <= lengthMove && distance <= maxDistance){

            count++;
            transform.Translate(direction * speed * Time.deltaTime);

        } else {
            count = 0f;
            moving = false;
        }

        if(distance >= maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, center.transform.position, Time.deltaTime);
        }
            
    }
}