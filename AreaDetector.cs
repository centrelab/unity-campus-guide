using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaDetector : MonoBehaviour
{

    public Text floorIndicator;
    public Text areaIndicator;

    //public Canvas guideUI;
    //public Canvas finderUI;

    public GameObject player;

    public Collider floor1;
    public Collider floor2;
    public Collider elevators1;
    public Collider elevators2;

    public Collider rangeOfGuide;

    Collider inArea;



    void Start()
    {
        deactivateGuide(); 
    }

    void OnTriggerEnter(Collider other)
    {

        if (other == elevators1)
        {
            inArea = elevators1;
        }
        else if (other == elevators2)
        {
            inArea = elevators2;

        }
        else if (other == floor1)
        {
            Debug.Log("Player entered floor1 area");
            floorIndicator.text = "Current floor: Floor 1";
        }
        else if (other == floor2)
        {
            Debug.Log("Player entered floor2 area");
            floorIndicator.text = "Current floor: Floor 2";

        }
        else if (other == rangeOfGuide)
        {
            inArea = rangeOfGuide;
            activateGuide();

        }
        else
        {
            Debug.Log("Player entered " + other.name + " area");
            inArea = other;
            areaIndicator.text = "Current area: " + other.name;
        }


    }


    void Update()
    {

        // checking to see if the player is still in the area specified by the collider
        if (inArea != null && !player.GetComponent<Collider>().bounds.Intersects(inArea.GetComponent<Collider>().bounds))
        {
            Debug.Log("Player left area");
            inArea = null;

        }

        if (!player.GetComponent<Collider>().bounds.Intersects(rangeOfGuide.GetComponent<Collider>().bounds))
        {
            deactivateGuide();
        }

    }

    private void activateGuide()
    {
        //guideUI.enabled = true;
        //finderUI.enabled = false;
    }


    private void deactivateGuide()
    {
        //guideUI.enabled = false;
        //finderUI.enabled = true;
    }
}