using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : MonoBehaviour
{
    public GameObject researchPanel;
    public GameCode Canvas;

    void Awake()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<GameCode>();
        researchPanel = Canvas.ResearchPanel;
        researchPanel.SetActive(false);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)){
            researchPanel.SetActive(true);
        }
    }
}
