using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    private HungryController hungryController;

    public GameObject gameOver;

    public Animator animator;

    public  float runSpeed = 40f;

    public Vector3 respawnCheckpoint;

    float horizontalMove = 0f;

    bool jump, crouch, isDeath;

    void Update()
    {   

        if (!isDeath)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            

        }

        if(Input.GetButtonDown("Jump"))
        {
             if (!isDeath)
            {
                jump = true;

                //animator.SetBool("IsJumping", true);

            }
            

        }

        if(Input.GetButtonDown("Crouch"))
        {
           
            crouch = true;

        }
        else if(Input.GetButtonUp("Crouch"))
        {
            
            crouch = false;

        }

        // if(Input.GetButtonDown("Cancel"))
        // {

        //     PlayerPrefs.SetInt("SavePosition", SceneManager.GetActiveScene().buildIndex);
        //     SceneManager.LoadScene(0);
        //     SaveSystem.SavePlayer(this);

        // }

        if (isDeath)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                HungryController.hungry = 100f;

                transform.position = respawnCheckpoint;

                isDeath = false;

                gameOver.SetActive(false);
                
                //animator.SetBool("Death", false);
                // Debug.Log("Back To Checkpoint");

            }
        }

        if (HungryController.hungry <= 0)
        {
            
            gameOver.SetActive(true);

            horizontalMove = 0;

            isDeath = true;

            //animator.SetBool("Death", true);

            Debug.Log("You're is death");

        }

    }

    public void OnLanding(){

        //animator.SetBool("IsJumping", false);

    }

    public void OnCrouching(bool isCrouching){

        //animator.SetBool("IsCrouching", isCrouching); 

    }

    void FixedUpdate()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
        
        if (HungryController.hungry <= 50)
        {
                
            runSpeed = 20f;

        }

        if(HungryController.hungry >= 50)
        {

            runSpeed = 30f;

        }


    }

   void OnCollisionEnter2D(Collision2D other)
   {
       if (other.gameObject.GetComponent<Rigidbody2D>() == null) return;
       
        if (other.gameObject.tag == "Enemy")
        {
        
            gameOver.SetActive(true);

            horizontalMove = 0;

            isDeath = true;

            //animator.SetBool("Death", true);

            Debug.Log("You're is death");
            
        }

   }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Checkpoint")
        {
            respawnCheckpoint = other.transform.position;
        }
        
        if (other.tag == "Enemy")
        {
            gameOver.SetActive(true);
            horizontalMove = 0;
            isDeath = true;
            //animator.SetBool("Death", true);
            print("Implaed");
        }

        if (other.tag == "Water")
        {
            gameOver.SetActive(true);
            horizontalMove = 0;
            isDeath = true;
            print("Drowned");
        }

    }

    public void SavePlayer(){

        SaveSystem.SavePlayer(this);

    }

    public void LoadPlayer(){
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavePosition"));
        PlayerData data =  SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        
    }

}
