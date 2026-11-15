using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Camera mainCamera;
    public float transparency = .5f;
    public GameCode Canvas;


    private SpriteRenderer[] childRenderers;
    private SpriteRenderer spriteRenderer;
    public bool placedDown = false;
    private bool touchingObject;
    private int buildingsTouching;
    // Start is called before the first frame update
    void Start()
    {

        Canvas = GameObject.Find("Canvas").GetComponent<GameCode>();

        mainCamera = Camera.main;

        childRenderers = GetComponentsInChildren<SpriteRenderer>();
        SetTransparency(transparency);
    }

    // Update is called once per frame
    void Update()
    {
        if(!placedDown){
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0f;

            transform.position = mouseWorldPos;


            if (Input.GetMouseButtonDown(0) && !touchingObject){
            Canvas.placing = false;
            placedDown = true;
            SetTransparency(1);
            if(Canvas.placingFarm){
                Canvas.placedFarm();
            }
        }
        }
    }

    public void SetTransparency(float alphaValue)
    {
        foreach (SpriteRenderer renderer in childRenderers)
        {
            Color currentColor = renderer.color;
            currentColor.a = alphaValue;
            renderer.color = currentColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building") || other.CompareTag("PostOffice"))
        {
            buildingsTouching++;
            touchingObject = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Building") || other.CompareTag("PostOffice"))
        {
            buildingsTouching = Mathf.Max(0, buildingsTouching - 1);
            touchingObject = buildingsTouching > 0;
        }   
    }
}
