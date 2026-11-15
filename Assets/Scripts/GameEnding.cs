using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

    public GameObject AItext;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Ending1;
    public GameObject Ending2;
    public GameObject Button3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void accept(){
        Button2.SetActive(false);
        Button1.SetActive(false);
        AItext.SetActive(false);
        Ending2.SetActive(true);
        Button3.SetActive(true);
    }
    public void decline(){
        Button2.SetActive(false);
        Button1.SetActive(false);
        AItext.SetActive(false);
        Ending1.SetActive(true);
        Button3.SetActive(true);
    }
    public void startGame(){
        SceneManager.LoadScene("MainGame");
    }
}
