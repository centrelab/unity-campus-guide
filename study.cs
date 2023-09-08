using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class study : MonoBehaviour
{
    public Texture[] textures; // Array of textures to cycle through
    private int currentTextureIndex = 0;
    private Renderer objectRenderer;

    //public GameObject guideCallingButton;
    //public TMP_Dropdown m_Dropdown;

    //Use these for adding options to the Dropdown List
    Dropdown.OptionData m_NewData, m_NewData2;
    //The list of messages for the Dropdown
    List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();

    public GameObject target;

    public CharacterController cc;
    public GameObject player;
    public GameObject pcamera;
    
    public float floor5Height;
    public Slider slider;
    public Button more;
    public Button less;
    public Button continueButton;
    public GameObject btnStop;
    public GameObject heightBoard;
    public GameObject movementArea;

    private void Start()
    {
        btnStop.SetActive(false);
        movementArea.SetActive(false);
        more.onClick.AddListener(delegate { increaseHeight(); });
        less.onClick.AddListener(delegate { decreaseHeight(); });
        continueButton.onClick.AddListener(delegate { allowGuide(); });


        objectRenderer = GetComponent<Renderer>();

        if (textures.Length > 0)
        {
            objectRenderer.material.mainTexture = textures[currentTextureIndex];
        }
        //hide guide calling button
        //guideCallingButton.SetActive(false);

        ////Clear the old options of the Dropdown menu
        //m_Dropdown.ClearOptions();
        ////Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
        //m_NewData = new Dropdown.OptionData();
        //m_NewData.text = "Elevators";
        //m_Messages.Add(m_NewData);
    }

    private void allowGuide()
    {
        movementArea.SetActive(true);
        btnStop.SetActive(true);
        heightBoard.SetActive(false);
    }

    private void decreaseHeight()
    {
        slider.value = slider.value + 0.1f;
    }

    private void increaseHeight()
    {
        slider.value = slider.value - 0.1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeTexture(false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeTexture(true);
        }
        if (Pathfinding.whichFloor == 5)
        {
            player.transform.position = new Vector3(player.transform.position.x, slider.value, player.transform.position.z);
        }
    }

    private void ChangeTexture(Boolean reverse)
    {
        if (textures.Length > 0)
        {
            if (!reverse)
            {
                currentTextureIndex = (currentTextureIndex + 1) % textures.Length;
                objectRenderer.material.mainTexture = textures[currentTextureIndex];
            }
            else
            {
                currentTextureIndex = (currentTextureIndex - 1) % textures.Length;
                objectRenderer.material.mainTexture = textures[currentTextureIndex];
            }
        }

        updateEnvironment();
    }

    private void updateEnvironment()
    {
        cc.gameObject.SetActive(false);
        Vector3 targetPosition;

        if (currentTextureIndex == 2)
        {
            targetPosition = target.transform.position;
            player.transform.position = targetPosition;
            Pathfinding.whichFloor = 5;
        }

        cc.gameObject.SetActive(true);
        //guideCallingButton.SetActive(true);
    }
}
