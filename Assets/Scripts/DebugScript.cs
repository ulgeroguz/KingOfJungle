using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DebugScript : MonoBehaviour
{
    public Light light;
    private GameObject player;
    public Camera camFar, fps, normal;
    public float speed;
    public GameObject enemy;
    public Material[] skies;
    public RenderSettings settings;
    public Dropdown dropdown;
    public GameObject debugPanel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void farCam()
    {
            
        camFar.enabled = true;
        normal.enabled = false;
       
        fps.enabled = false;
    }
    public void NormalCam()
    {


        camFar.enabled = false;
        fps.enabled = false;
        normal.enabled = true;
    }
    //public void FpsCam()
    //{

    //    normal.enabled = false;
    //    camFar.enabled = false;
    //    fps.enabled = true;
    //}

    public void EnemyOn()
    {
        enemy.SetActive(true);
    }
    public void EnemyFalse()
    {
        enemy.SetActive(false);
    }

    public void skyChange()
    {
        foreach (var material in skies)
        {
            if (material.name==dropdown.options[dropdown.value].text)
            {
                RenderSettings.skybox = material;
            }
           
        }
      

    }
    public void Retry()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Resume()
    {

        debugPanel.SetActive(false);
        Time.timeScale = 1;

    }
    public void SettingsOpen()
    {

        debugPanel.SetActive(true);
        Time.timeScale = 0;

    }
    //public void SpeedText()
    //{        Movement._speed = int.Parse(speedfield.text);
    //}
}
