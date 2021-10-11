using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject losepanel;
    public GameObject endBox;
    public Player player;

    // Start is called before the first frame update
    

    public void Finish()
    {
        if (player.animalText.text=="Heroic"|| (player.animalText.text == "Supreme"))
        {
            panel.SetActive(true);
        }
        else
        {
            losepanel.SetActive(true);
        }
     
    }
   
    public void Retry()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
