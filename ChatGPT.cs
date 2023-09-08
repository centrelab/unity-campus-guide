using System;
using System.Collections;

using UnityEngine;

using System.IO;
using System.Diagnostics;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class ChatGPT : MonoBehaviour
{
    private string audio_file_path;
    private string txt_file_path;
    private AudioSource audioSource;
    private int audio_state = 0;

    private const uint LOCK = 1;

    private IntPtr window;

    //public TMP_Text txt_answer;
    //public Button btnStop;
    public Animator agentAnim;

    public AudioClip speech;
    private float marker;
    public Boolean activated;

    // Start is called before the first frame update
    void Start()
    {
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
        //if (File.Exists(audio_file_path))
        //{
        //    var clip = audioSource.clip;
        //    switch (audio_state)
        //    {
        //        case 0:
        //            if (clip == null)
        //            {
        //                // audio = this.gameObject.AddComponent<AudioSource>();
        //                System.Threading.Thread.Sleep(500);
        //                StartCoroutine(LoadAudio(audio_file_path));
        //                audio_state = 1;
        //            }
        //            break;
        //        case 1:
        //            if (audioSource.isPlaying)
        //            {
        //                UnityEngine.Debug.Log("Audio is playing");
        //                audio_state = 2;
        //                StreamReader reader = new StreamReader(txt_file_path);
        //                //txt_answer.text = reader.ReadToEnd();
        //                reader.Close();
        //            }
        //            break;
        //        case 2:
        //            if (!audioSource.isPlaying)
        //            {
        //                agentAnim.SetBool("talk", false);
        //                UnityEngine.Debug.Log("Delete audio file: " + audio_file_path);
        //                File.Delete(audio_file_path);
        //                audioSource.clip = null;
                        
        //                // Destroy(audio);
        //                // audio = null;
        //                audio_state = 0;

        //                //txt_answer.text = "Speech Recognition Ready";
        //            }
        //            break;
        //    }
        //}

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
        //UnityEngine.Debug.Log("Execute STT_ChatGPT.exe");

        //Process process = new Process();
        //process.StartInfo.FileName = Application.dataPath + "/STT_ChatGPT.exe";
        ////Minimize the CMD window of STT_ChatGPT
        //process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
        //process.Start();

        ////Make Unity Windows active
        //LockSetForegroundWindow(LOCK);
        //window = GetActiveWindow();
        //StartCoroutine(Checker());


        //this.GetComponent<Button>().interactable = false;
        //btnStop.interactable = true;

        //txt_answer.text = "Speech Recognition Ready";

        StartCoroutine(TalkAboutBuilding());

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

    private IEnumerator LoadAudio(string path)
    {
        UnityEngine.Debug.Log("Load audio file: " + audio_file_path);
        WWW request = new WWW(path);
        yield return request;
        audioSource.clip = request.GetAudioClip();
        audioSource.clip.name = name;
        audioSource.Play();
        agentAnim.SetBool("talk", true);
    }

    IEnumerator Checker()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);
            IntPtr newWindow = GetActiveWindow();

            if (window != newWindow)
            {
                UnityEngine.Debug.Log("Set to foreground");
                SwitchToThisWindow(window, true);
            }
        }
    }

    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();
    [DllImport("user32.dll")]
    static extern bool LockSetForegroundWindow(uint uLockCode);
    [DllImport("user32.dll")]
    static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
}
