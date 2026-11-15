using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduction : MonoBehaviour
{
    public GameCode script;
    public GameObject humanPrefab;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Canvas").GetComponent<GameCode>();
        StartCoroutine(RunEverySecond());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator RunEverySecond()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        while(true){
            if (script.humans < script.maxHumans)
            {
                if(Random.Range(0, 10) == 1){
                    script.humans++;
                    Instantiate(humanPrefab, transform.position, transform.rotation);
                }
            }
            yield return wait;
        }
    }
}
