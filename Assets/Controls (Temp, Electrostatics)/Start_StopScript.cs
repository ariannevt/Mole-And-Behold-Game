using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Start_StopScript : MonoBehaviour  //attached to the Start/Stop Button
{
    public TMP_Text PlayPauseButtonText;
    public Color32 GreenForPlay;
    public Color32 RedForPause;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;  //game will start in paused mode until User clicks "Play"
        PlayPauseButtonText.text = "Play";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePlay_Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PlayPauseButtonText.text = "Pause";
            GetComponent<Image>().color = RedForPause;
        }

        else
        {
            Time.timeScale = 0;
            PlayPauseButtonText.text = "Play";
            GetComponent<Image>().color = GreenForPlay;
        }
    }
}
