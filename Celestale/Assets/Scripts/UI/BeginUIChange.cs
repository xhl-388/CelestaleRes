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
        UI_Start.SetActive(true);
        UI_Begin.SetActive(false);
    }
    public void ExitStartGame()
    {
        UI_Start.SetActive(false);
        UI_Begin.SetActive(true);

    }
    public void SearchTower()
    {
        UI_Begin.SetActive(false);
        UI_SearchTower.SetActive(true);
    }
    public void ExitSearchTower()
    {
        UI_Begin.SetActive(true);
        UI_SearchTower.SetActive(false) ;
    }
    public void SearchCharacter()
    {
        UI_Begin.SetActive(false);
        UI_SearchChara.SetActive(true);
    }
    public void ExitSearchCharacter()
    {
        UI_Begin.SetActive(true);
        UI_SearchChara.SetActive(false) ;
    }
    public void Settings()
    {
        UI_Begin.SetActive(false);
        UI_Settings.SetActive(true);
    }
    public void ExitSettings()
    {
        UI_Begin.SetActive(true);
        UI_Settings.SetActive(false);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
