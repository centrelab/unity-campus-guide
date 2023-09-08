using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sticky : MonoBehaviour
{
    public Button paper;
    public GameObject paperText;
    public GameObject cross;

    void Start()
    {
        cross.SetActive(false);
        paperText.SetActive(true);
        paper.onClick.AddListener(delegate { checkPaper(); });
    }

    private void checkPaper()
    {
        cross.SetActive(true);
        paperText.SetActive(false);
    }
}
