using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using Microsoft.Cci;
using UnityEngine.Timeline;

public class Pathfinding : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject elevators;
    public GameObject elevators2;
    public GameObject elevators3;
    public GameObject elevators4;
    public GameObject elevators5;
    public GameObject elevators6;
    public GameObject elevators7;
    public GameObject office;
    public GameObject sticky1;
    public GameObject sticky2;
    public GameObject sticky3;
    public GameObject sticky4;
    public GameObject sticky5;
    public GameObject sticky6;
    public GameObject sticky7;
    public GameObject sticky8;
    public GameObject sticky9;

    public GameObject[] targets;
    public AudioSource[] audioSources;
    int index = 0;
    public AudioSource audioSource;

    public Button option1;
    public TMP_Dropdown destination;

    public Animator walkingAnimation;

    public FaceUser fu;
    public GameObject model;

    public GameObject player;

    private GameObject destinationRange;
    public Button btnStop;

    public Boolean symbolGuide;
    public Renderer arrowRenderer;
    public Renderer markerRenderer;
    public Renderer stopRenderer;

    public Boolean isTutorial;
    public static int whichFloor = 1;

    public Button btnNext;
    public GameObject blocker;



    void Start() {
        //option1.onClick.AddListener(delegate { navigateToSelection(); });
        destinationRange = elevators;

        btnStop.onClick.AddListener(delegate { StopWalking(false); });

        btnNext.onClick.AddListener(delegate { NextStep(); });


        if (symbolGuide)
        {
            changeToMarker();
        }

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].enabled = false;
        }
        //audioSource = audioSources[0];
    }

    private void NextStep()
    {
        btnNext.gameObject.SetActive(false);
        //walkingAnimation.SetBool("talk", true);
        StartCoroutine(TalkAboutBuilding());
        agent.SetDestination(targets[index].transform.position);
        destinationRange = targets[index];
        index++;
        //audioSource = audioSources[index];
    }


    private IEnumerator TalkAboutBuilding()
    {
        audioSources[index].enabled = true;
        audioSources[index].enabled = true;
        yield return new WaitForSeconds(audioSources[index].clip.length);
        //walkingAnimation.SetBool("talk", false);
        audioSources[index].enabled = false;

        fu.enabled = false;
        transform.LookAt(agent.steeringTarget);
        walkingAnimation.SetBool("walk", true);

    }

    private void clearRenderers()
    {
        arrowRenderer.enabled = false;
        markerRenderer.enabled = false;
        stopRenderer.enabled = false;
    }

    private void changeToArrow()
    {
        clearRenderers();
        arrowRenderer.enabled = true;
    }

    private void changeToMarker()
    {
        clearRenderers();
        markerRenderer.enabled = true;
    }

    private void changeToStop()
    {
        clearRenderers();
        stopRenderer.enabled = true;
    }

    //private void navigateToSelection()
    //{
    //    if (symbolGuide)
    //    {
    //        changeToArrow();
    //    }

    //    Debug.Log(destination.value);
    //    if (destination.value == 0)
    //    {
    //        return;
    //    }
    //    else if (destination.value == 1)
    //    {
    //        if (whichFloor == 1)
    //        {
    //            agent.SetDestination(elevators.transform.position);
    //            destinationRange = elevators;
    //        }
    //        else if (whichFloor == 2)
    //        {
    //            agent.SetDestination(elevators2.transform.position);
    //            destinationRange = elevators2;
    //        }
    //        else if (whichFloor == 3)
    //        {
    //            agent.SetDestination(elevators3.transform.position);
    //            destinationRange = elevators3;
    //        }
    //        else if (whichFloor == 4)
    //        {
    //            agent.SetDestination(elevators4.transform.position);
    //            destinationRange = elevators4;
    //        }
    //        else if (whichFloor == 5)
    //        {
    //            agent.SetDestination(elevators5.transform.position);
    //            destinationRange = elevators5;
    //        }
    //        else if (whichFloor == 6)
    //        {
    //            agent.SetDestination(elevators6.transform.position);
    //            destinationRange = elevators6;
    //        }
    //        else if (whichFloor == 7)
    //        {
    //            agent.SetDestination(elevators7.transform.position);
    //            destinationRange = elevators7;
    //        }
    //    }
    //    else if (destination.value == 2)
    //    {
    //        if (isTutorial)
    //        {
    //            agent.SetDestination(office.transform.position);
    //            destinationRange = office;
    //        }
    //        else
    //        {
    //            agent.SetDestination(sticky1.transform.position);
    //            destinationRange = sticky1;
    //        }
    //    }
    //    else if (destination.value == 3)
    //    {
    //        agent.SetDestination(sticky2.transform.position);
    //        destinationRange = sticky2;
    //    }
    //    else if (destination.value == 4)
    //    {
    //        agent.SetDestination(sticky3.transform.position);
    //        destinationRange = sticky3;
    //    }
    //    else if (destination.value == 5)
    //    {
    //        agent.SetDestination(sticky4.transform.position);
    //        destinationRange = sticky4;
    //    }
    //    else if (destination.value == 6)
    //    {
    //        agent.SetDestination(sticky5.transform.position);
    //        destinationRange = sticky5;
    //    }
    //    else if (destination.value == 7)
    //    {
    //        agent.SetDestination(sticky6.transform.position);
    //        destinationRange = sticky6;
    //    }
    //    else if (destination.value == 8)
    //    {
    //        agent.SetDestination(sticky7.transform.position);
    //        destinationRange = sticky7;
    //    }
    //    else if (destination.value == 9)
    //    {
    //        agent.SetDestination(sticky8.transform.position);
    //        destinationRange = sticky8;
    //    }
    //    else if (destination.value == 10)
    //    {
    //        agent.SetDestination(sticky9.transform.position);
    //        destinationRange = sticky9;
    //    }

    //    fu.enabled = false;
    //    transform.LookAt(agent.steeringTarget);
    //    walkingAnimation.SetBool("walk", true);

    //}

    // Update is called once per frame
    void Update()
    {

        if (model.GetComponent<Collider>().bounds.Intersects(destinationRange.GetComponent<Collider>().bounds))
        {
            btnNext.gameObject.SetActive(true);
            StopWalking(true);
        }



        if (!fu.enabled) { 
            model.transform.LookAt(agent.steeringTarget);
        }


        blocker.transform.position = model.transform.position;


     }

    

    public void TeleportToPlayer()
    {


        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        float spawnDistance = 3f;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        StopWalking(false);

        agent.enabled = false;
        transform.position = spawnPos;

        agent.enabled = true;

    }
    void StopWalking(bool reachedDestination)
    {
        if (symbolGuide)
        {
            if (reachedDestination)
            {
                changeToMarker();
            } else
            {
                changeToStop();
            }
        }

        
        agent.isStopped = true;
        agent.ResetPath();
        fu.enabled = true;
        walkingAnimation.SetBool("walk", false);
    }
}
