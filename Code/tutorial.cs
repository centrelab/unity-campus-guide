using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class tutorial : MonoBehaviour
{
    public Texture[] textures; // Array of textures to cycle through
    private int currentTextureIndex = 0;
    private Renderer objectRenderer;

    public GameObject guideCallingButton;
    public TMP_Dropdown m_Dropdown;

    //Use these for adding options to the Dropdown List
    Dropdown.OptionData m_NewData, m_NewData2;
    //The list of messages for the Dropdown
    List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();


    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (textures.Length > 0)
        {
            objectRenderer.material.mainTexture = textures[currentTextureIndex];
        }
        // hide guide calling button
        guideCallingButton.SetActive(false);

        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();
        //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
        m_NewData = new Dropdown.OptionData();
        m_NewData.text = "Elevators";
        m_Messages.Add(m_NewData);
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
        if (currentTextureIndex == 3)
        {
            guideCallingButton.SetActive(true);
        }

        if (currentTextureIndex == 7)
        {
            m_NewData2 = new Dropdown.OptionData();
            m_NewData2.text = "Office";
            m_Messages.Add(m_NewData2);
        }
    }
}
