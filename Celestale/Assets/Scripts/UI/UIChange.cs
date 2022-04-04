using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIChange : MonoBehaviour
{
    private GameObject UI_GamePlay;
    private GameObject UI_Settings;
    private GameObject UI_Defeated;
    private GameObject UI_Success;
    private void Awake()
    {
        UI_GamePlay = transform.GetChild(0).gameObject;
        UI_Settings = transform.GetChild(1).gameObject;
        UI_Defeated = transform.GetChild(2).gameObject;
        UI_Success = transform.GetChild(3).gameObject;
    }
    private void Start()
    {
        UI_Settings.SetActive(false);
        UI_Defeated.SetActive(false);
        UI_Success.SetActive(false);
    }
    public void Pause()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_GamePlay.SetActive(false);
        UI_Settings.SetActive(true);
        Time.timeScale = 0;
    }
    public void DePause()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_GamePlay.SetActive(true);
        UI_Settings.SetActive(false);
        Time.timeScale = 1;
    }
    public void Fail()
    {
        UI_Defeated.SetActive(true);
        UI_GamePlay.SetActive(false);
        Time.timeScale = 0;
    }
    public void Success()
    {
        UI_Success.SetActive(true);
        UI_GamePlay.SetActive(false);
        Time.timeScale = 0;
    }
    public void Next()
    {
        BGMController.instance.SaveVolume();
        if (SceneManager.GetActiveScene().buildIndex != 7)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
