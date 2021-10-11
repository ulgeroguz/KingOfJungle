using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : ThrowAway
{

 
    public GameObject[] playerAvatars;
    public Animator animator;
    public Animator bear_animator;
    public AudioSource audioSource;
    public AudioClip[] clips;
    public ParticleSystem[] particles;
    public Transform player;
    public int evolutionCount;
    private bool finish;
    public TextMesh animalText;
    public Slider evolutionSlider;
    public ForwardMovement fr;
    public SidewayMovement Sd;
    public Camera mainCam;
    public Camera BearCam;
    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
          
        }

      
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Meat")
        {
            particles[1].Play();
            Destroy(other.gameObject);

            if (evolutionCount <= 19)
            {
                evolutionCount++;
                evolutionSlider.value += 1;
            }

            if (evolutionCount>=7&&evolutionCount<14)
            {
                BoldCat();
            }
            else if (evolutionCount >= 14)
            {
                King();
            }
        }
        if (other.gameObject.tag == "Veggie")
        {
            particles[2].Play();
            Destroy(other.gameObject);
          
            if (evolutionCount>=1)
            {
                evolutionCount--;
                evolutionSlider.value -= 1;
            }

            if (evolutionCount<7)
            {

                PussyCat();
            }
            else if (evolutionCount >6&&evolutionCount<14)
            {

                BoldCat();
            }
        }

     
        if (other.gameObject.tag=="Enemy")
        {
            animator.SetTrigger("GetHit");
            fr.enabled = false;
            Sd.enabled = false;
            particles[5].Play();
            particles[6].Play();
            Invoke("gethit", 2);

        }
        if (other.gameObject.tag == "Finish")
        {
            animator.SetTrigger("Wait");
            mainCam.enabled = false;
            BearCam.enabled = true;
            Invoke("CutScene", 2f);
            Invoke("CutSceneAttack", 4f);
            player.position = new Vector3(3.6f, player.position.y, player.position.z);
            if (evolutionCount==20)
            {
                power = 20;
            }
            else if (evolutionCount==18|| evolutionCount == 19)
            {
                power = 18;
            }
            else if (evolutionCount>=15)
            {
                power = 16;
            }
            else if (evolutionCount >= 11 )
            {
                power = 14;
            }
            else if (evolutionCount >= 7 )
            {
                power = 11;
            }
            bear_animator.enabled = true;
            Invoke("ExplodeWait", 5);
           
            fr.enabled = false;
            Sd.enabled = false;
            Invoke("waitNOpen", 8);

        }
       
    }

   private void waitNOpen()
    {
        gm.Finish();
    }
    public void CutScene()
    {
        mainCam.enabled = true;
        BearCam.enabled = false;
    }
    public void CutSceneAttack()
    {
        mainCam.enabled = true;
        BearCam.enabled = false;
        animator.SetTrigger("Attack");
       

    }
    public void ExplodeWait()
    {
        particles[7].Play();
        particles[8].Play();
        mainCam.enabled = false;
        BearCam.enabled = true;
        Explode();
    }
   public void gethit()
    {
        
        evolutionCount -= 2;
        evolutionSlider.value -= 2;
                  
        if (evolutionCount > 13)
        {
            animator.SetTrigger("Run");
            King();

        }
        if (evolutionCount > 6 && evolutionCount <= 13)
        {
            animator.SetTrigger("Trot");
            BoldCat();

        }
        if (evolutionCount >= 0 && evolutionCount <= 6)
        {
            animator.SetTrigger("Walk");
            PussyCat();

        }
        fr.enabled = true;
        Sd.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Red")
        {
            particles[3].Play();
            evolutionCount -= 2;
            if (evolutionCount <= 0)
            {
                evolutionCount = 0;
            }
            evolutionSlider.value -= 2;
            

        
            if (evolutionCount >= 0&&evolutionCount<=6)
            {

                PussyCat();
            }
            if (evolutionCount > 6 && evolutionCount <= 13)
            {
                BoldCat();
            }
            else if (evolutionCount > 13)
            {
                King();
            }
        }
        if (other.gameObject.tag == "Green")
        {
            particles[4].Play();
            evolutionCount += 2;
            if (evolutionCount>=20)
            {
                evolutionCount = 20;
            }

            
            if (evolutionCount >= 0 && evolutionCount <= 6)
            {

                PussyCat();
            }
            if (evolutionCount > 6 && evolutionCount <= 13)
            {
                BoldCat();
            }
            else if (evolutionCount > 13)
            {
                King();
            }
        }

    }

    private void PussyCat()
    {
        evolutionSlider.gameObject.transform.localPosition = new Vector3(evolutionSlider.gameObject.transform.localPosition.x, -6.2f, evolutionSlider.gameObject.transform.localPosition.z);

        animalText.text = "Chicken";
        if (!playerAvatars[0].activeSelf)
        {
            particles[0].Play();
            playerAvatars[0].SetActive(true);
            playerAvatars[1].SetActive(false);

            evolutionSlider.value = evolutionCount % 7;
            animator = playerAvatars[0].GetComponent<Animator>();
            animator.SetTrigger("Walk");
        }
    }
    private void BoldCat()
    {
        evolutionSlider.gameObject.transform.localPosition = new Vector3(evolutionSlider.gameObject.transform.localPosition.x, 53f, evolutionSlider.gameObject.transform.localPosition.z);
        evolutionSlider.value = evolutionCount%7;
        animalText.text = "Heroic";
        
        if (!playerAvatars[1].activeSelf)
        {
            particles[0].Play();
            playerAvatars[0].SetActive(false);
            playerAvatars[1].SetActive(true);
            playerAvatars[2].SetActive(false);
            animator = playerAvatars[1].GetComponent<Animator>();
            animator.SetTrigger("Trot");
        }
    }
    private void King()
    {
        evolutionSlider.gameObject.transform.localPosition = new Vector3(evolutionSlider.gameObject.transform.localPosition.x, 90f, evolutionSlider.gameObject.transform.localPosition.z);
        evolutionSlider.value = evolutionCount % 7;
        animalText.text = "Supreme";
       
   
        if (!playerAvatars[2].activeSelf)
        {
            particles[0].Play();
            playerAvatars[1].SetActive(false);
            playerAvatars[2].SetActive(true);
            animator = playerAvatars[2].GetComponent<Animator>();
            animator.SetTrigger("Run");
        }
       
    }


    
   }
