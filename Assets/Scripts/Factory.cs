using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private GameCode gamecode;
    public float amountGained = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gamecode = gamecode = GameObject.Find("Canvas").GetComponent<GameCode>();
        gamecode.goldGain = gamecode.goldGain + amountGained;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
