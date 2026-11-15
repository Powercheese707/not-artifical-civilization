using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public GameObject destroyPanel;
    private GameCode Canvas;
    private FollowMouse followMouse;
    public bool waiting;
    public string typeBuilding;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<GameCode>();
        destroyPanel = Canvas.DestroyPanel;
        followMouse = GetComponent<FollowMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Canvas.destroyed && waiting){

            if(typeBuilding == "house"){
                Canvas.maxHumans = Canvas.maxHumans - 3 - Canvas.houseUpgraded;
            }
            if(typeBuilding == "apartment"){
                Canvas.maxHumans = Canvas.maxHumans - 10;
            }
            if(typeBuilding == "factory"){
                Canvas.goldGain = Canvas.goldGain - 3;
            }
            if(typeBuilding == "gold mine"){
                Canvas.goldGain = Canvas.goldGain - 8;
            }
            if(typeBuilding == "farm"){
                Canvas.foodGain = Canvas.foodGain - 5 - Canvas.farmingUpgraded;
            }




            Destroy(gameObject);
            Canvas.destroyed = false;
        }
        if (Canvas.notDestroyed){
            Canvas.destroyed = false;
            waiting = false;
            Canvas.notDestroyed = false;
            
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && followMouse.placedDown){
            destroyPanel.SetActive(true);
            waiting = true;
        }
    }
}
