using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    private GameCode gamecode;
    public float Gain = 5f;
    public GameObject cow;
    // Start is called before the first frame update
    void Start()
    {
        gamecode = gamecode = GameObject.Find("Canvas").GetComponent<GameCode>();
        gamecode.foodGain = gamecode.foodGain + Gain + gamecode.farmingUpgraded;
        gamecode.amountFarms++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void summonCow(){
        Instantiate(cow, transform.position, transform.rotation);
        Instantiate(cow, transform.position, transform.rotation);
        Instantiate(cow, transform.position, transform.rotation);
    }
}
