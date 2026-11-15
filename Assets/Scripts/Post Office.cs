using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostOffice : MonoBehaviour
{
    public GameObject postMan;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunEverySecond());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RunEverySecond()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);

        while(true){
            if (Random.Range(0, 2) == 1){
                Instantiate(postMan, transform.position, transform.rotation);
            }
            
            yield return wait;
        }
    }
}
