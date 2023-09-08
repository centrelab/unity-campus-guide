using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Elevators : MonoBehaviour
{
    public Button f1Button;
    public Button f2Button;
    public Button f3Button;
    public Button f4Button;
    public Button f5Button;
    public Button f6Button;
    public Button f7Button;

    public GameObject targetFloor1;
    public GameObject targetFloor2;
    public GameObject targetFloor3;
    public GameObject targetFloor4;
    public GameObject targetFloor5;
    public GameObject targetFloor6;
    public GameObject targetFloor7;


    public int floor;

    public CharacterController cc;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (floor != 1)
        {
            f1Button.onClick.AddListener(delegate { MoveToFloor(1); });
        } 
        if (floor != 2)
        {
            f2Button.onClick.AddListener(delegate { MoveToFloor(2); });
        }
        if (floor != 3)
        {
            f3Button.onClick.AddListener(delegate { MoveToFloor(3); });
        }
        if (floor != 4)
        {
            f4Button.onClick.AddListener(delegate { MoveToFloor(4); });
        }
        if (floor != 5)
        {
            f5Button.onClick.AddListener(delegate { MoveToFloor(5); });
        }
        if (floor != 6)
        {
            f6Button.onClick.AddListener(delegate { MoveToFloor(6); });
        }
        if (floor != 7)
        {
            f7Button.onClick.AddListener(delegate { MoveToFloor(7); });
        }
    }

    void Update()
    {
        // temporary for use without headset
        //if (input.getkey(keycode.u))
        //{
        //    player.transform.position = new vector3(1.4f, 3.33f, 7.27f);
        //}


    }

    private void MoveToFloor(int destination)
    {
        cc.gameObject.SetActive(false);
        Vector3 targetPosition;

        if (destination == 1) {
            targetPosition = targetFloor1.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 1;
        } else if (destination == 2) {
            targetPosition = targetFloor2.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 2;
            Debug.Log(Pathfinding.whichFloor);
        } else if (destination == 3) {
            targetPosition = targetFloor3.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 3;
        } else if (destination == 4) {
            targetPosition = targetFloor4.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 4;
        } else if (destination == 5) {
            targetPosition = targetFloor5.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 5;
        } else if (destination == 6) {
            targetPosition = targetFloor6.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 6;
        } else if (destination == 7) {
            targetPosition = targetFloor7.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 7;
        }

        //player.transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, player.transform.position.z);
        cc.gameObject.SetActive(true);
    }
}
