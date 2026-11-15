using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCode : MonoBehaviour
{
    public GameObject house;
    public float houseCost = 100f;
    public GameObject factory;
    public float factoryCost;
    public GameObject apartment;
    public float apartmentCost;
    public GameObject goldMine;
    public float goldMineCost;
    public GameObject postOffice;
    public float postOfficeCost;
    public GameObject farm;
    public float farmCost;
    public GameObject center;
    public float centerCost;




    public float gold = 0f;
    public float goldGain = 1f;
    public float maxHumans = 2;
    public float food = 50;
    public float foodGain = 0;
    public float humans;
    public bool placing = false;
    public bool placingFarm = false;
    private GameObject spawned;
    public GameObject ResearchPanel;
    public float amountFarms = 0f;
    public float farmingUpgraded = 0;
    public float postOfficeUpgraded = 0;
    public float houseUpgraded = 0;
    public bool destroyed = false;
    public bool notDestroyed = false;
    public float goldUpgrade = 100;

    public GameObject DestroyPanel;


    public TMP_Text goldText;
    public TMP_Text humanText;
    public TMP_Text foodText;

    public TMP_Text humanFoodText;
    public TMP_Text humanPostalText;
    public TMP_Text humanHouseText;
    public TMP_Text humanAIText;



    private Vector3 mousePos;

    void Start(){
        StartCoroutine(RunEverySecond());

    }





    public void placeBuildingHouse(){
        if (gold >= houseCost && !placing) {
            placing = true;
            spawned = Instantiate(house);
            gold = gold - houseCost;
        }

    }

    public void placeBuildingFactory(){
        if (gold >= factoryCost && !placing) {
            placing = true;
            spawned = Instantiate(factory);
            gold = gold - factoryCost;
        }

    }

    public void placeBuildingApartment(){
        if (gold >= apartmentCost && !placing) {
            placing = true;
            spawned = Instantiate(apartment);
            gold = gold - apartmentCost;
        }

    }

    public void placeBuildingGoldMine(){
        if (gold >= goldMineCost && !placing) {
            placing = true;
            spawned = Instantiate(goldMine);
            gold = gold - goldMineCost;
        }

    }

    public void placeBuildingPostOffice(){
        if (gold >= postOfficeCost && !placing) {
            placing = true;
            spawned = Instantiate(postOffice);
            gold = gold - postOfficeCost;
        }

    }

    public void placeBuildingFarm(){
        if (gold >= farmCost && !placing) {
            placing = true;
            placingFarm = true;
            spawned = Instantiate(farm);
            gold = gold - farmCost;
        }

    }

    public void placeBuildingCenter(){
        if (gold >= centerCost && !placing) {
            placing = true;
            spawned = Instantiate(center);
            gold = gold - centerCost;
        }

    }





    public void upgradeFarming(){
        if(farmingUpgraded == 0 && humans >= 50){
            foodGain = foodGain + (amountFarms * 2);
            farmingUpgraded = 5;
        }
    }
    public void upgradePostOffice(){
        if(postOfficeUpgraded == 0 && humans >= 70){
            postOfficeUpgraded = 30;
            goldUpgrade = 250;
        }
    }
    public void upgradeHouses(){
        if(houseUpgraded == 0 && humans >= 100){
            houseUpgraded = 5;
        }
    }
    public void GameWon(){
        if(humans >= 300){
            SceneManager.LoadScene("GameWon");
        }
    }
    public void closeResearch(){
        ResearchPanel.SetActive(false);
    }




    public void placedFarm(){
        spawned.GetComponent<Farm>().summonCow();
        placingFarm = false;
    }

    public void changeResources(){
        gold = gold + goldGain;
        food = food + foodGain;
        food = food - humans;
        if (gold < 0){
            gold = 0;
        }
        if (gold > goldUpgrade){
            gold = gold - Mathf.Round(humans/2);
        }
    }





    public void closeDestroyPanel(){
        DestroyPanel.SetActive(false);
        notDestroyed = true;
    }

    public void DestroyObject(){
        DestroyPanel.SetActive(false);
        destroyed = true;
    }
    // Update is called once per frame
    void Update()
    {
        goldText.text = "" + gold;
        humanText.text = humans + " / " + maxHumans;
        humanFoodText.text = humans + " / 50";
        foodText.text = "" + food;
        humanPostalText.text = humans + " / 70";
        humanHouseText.text = humans + " / 100";
        humanAIText.text = humans + " / 300";


        if (food <= 0){
            SceneManager.LoadScene("GameLost");
        }
    }















    IEnumerator RunEverySecond()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        while(true){
            changeResources();
            yield return wait;
        }
    }
}
