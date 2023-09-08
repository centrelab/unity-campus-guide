using System;
using System.Collections;

using UnityEngine;

using System.IO;
using System.Diagnostics;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class cmd2 : MonoBehaviour
{
    private string audio_file_path;
    private string txt_file_path;
    private AudioSource audioSource;
    private int audio_state = 0;

    private const uint LOCK = 1;

    private IntPtr window;

    //public TMP_Text txt_answer;
    public Button btnStop;
    public Animator agentAnim;

    public AudioClip speech;
    private float marker;
    public Boolean activated;

    // Start is called before the first frame update
    void Start()
    {

        btnStop.onClick.AddListener(delegate { ShutUp(); });

        audio_file_path = Application.dataPath + "/../answer/answer.wav";
        txt_file_path = Application.dataPath + "/../answer/answer.txt";

        //btnStop.interactable = false;

        if (File.Exists(audio_file_path)) File.Delete(audio_file_path);

        audioSource = GetComponent<AudioSource>();
        //agentAnim = GameObject.Find("Agent").GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            OnClickStart();
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            UnityEngine.Debug.Log("done talking");
            audioSource.enabled = false;
            audioSource.Stop();
            StopCoroutine(TalkAboutBuilding());
        }

    }

    public void OnClickStart()
    {
        StartCoroutine(TalkAboutBuilding());
    }

    private void ShutUp()
    {
        UnityEngine.Debug.Log("shut up");
        audioSource.enabled = false;
        audioSource.Stop();
        StopCoroutine(TalkAboutBuilding());
    }

    private IEnumerator TalkAboutBuilding()
    {
        audioSource.enabled = true;
        marker = Time.deltaTime;
        float marker2 = marker;
        yield return new WaitForSeconds(audioSource.clip.length);
        if (marker2 == marker)
        {
            UnityEngine.Debug.Log("done talking");
            audioSource.enabled = false;
        }

    }
}
