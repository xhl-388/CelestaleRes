using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginUIChange : MonoBehaviour
{
    private GameObject UI_Begin;
    private GameObject UI_SearchTower;
    private GameObject UI_SearchChara;
    private GameObject UI_Settings;
    private GameObject UI_Start;
    private void Awake()
    {
        UI_Begin = transform.GetChild(0).gameObject;
        UI_SearchTower = transform.GetChild(1).gameObject;
        UI_SearchChara = transform.GetChild(2).gameObject;
        UI_Settings = transform.GetChild(3).gameObject;
        UI_Start = transform.GetChild(4).gameObject;
    }
    private void Start()
    {
        UI_SearchChara.SetActive(false);
        UI_SearchTower.SetActive(false);
        UI_Settings.SetActive(false);
        UI_Start.SetActive(false);
    }
    public void StartGame()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Start.SetActive(true);
        UI_Begin.SetActive(false);
    }
    public void ExitStartGame()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Start.SetActive(false);
        UI_Begin.SetActive(true);

    }
    public void SearchTower()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Begin.SetActive(false);
        UI_SearchTower.SetActive(true);
    }
    public void ExitSearchTower()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Begin.SetActive(true);
        UI_SearchTower.SetActive(false) ;
    }
    public void SearchCharacter()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Begin.SetActive(false);
        UI_SearchChara.SetActive(true);
    }
    public void ExitSearchCharacter()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Begin.SetActive(true);
        UI_SearchChara.SetActive(false) ;
    }
    public void Settings()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Begin.SetActive(false);
        UI_Settings.SetActive(true);
    }
    public void ExitSettings()
    {
        UseInterfaceAudio.instance.PlayClip(UseInterfaceAudio.instance.click);
        UI_Begin.SetActive(true);
        UI_Settings.SetActive(false);
    }
    public void ExitGame()
    {
        BGMController.instance.SaveVolume();
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
