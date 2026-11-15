using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public float houseCapactiy = 5f;
    private GameCode gamecode;
    // Start is called before the first frame update
    void Start()
    {
        gamecode = GameObject.Find("Canvas").GetComponent<GameCode>();

        gamecode.maxHumans = gamecode.maxHumans + houseCapactiy + gamecode.houseUpgraded;
    }

    // Update is called once per frames
    void Update()
    {
        
    }
}
