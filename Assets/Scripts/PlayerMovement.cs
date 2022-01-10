using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public GameObject gameOver;

    public Animator animator;

    public  float runSpeed = 40f;

    public Vector3 respawnCheckpoint;

    float horizontalMove = 0f;

    public GameObject LandingCheck;

    bool jump, isDeath, isJumping, isMoving;

    public static bool interacting;

    public AudioSource walkSound;

    SaveSystem playerPosData;



    private void Awake()
    {
        playerPosData = FindObjectOfType<SaveSystem>();
        playerPosData.PlayerPosLoad();
    }

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
                animator.SetBool("IsJumping", true);
                jump = true;
                isJumping = true;
            }
        }

        if (isJumping)
        {
            OnLanding();            
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            transform.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }


        if (isDeath)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = respawnCheckpoint;
                isDeath = false;
                gameOver.SetActive(false);
                animator.SetBool("Death", false);
            }
        }
        
    }

    public void OnLanding(){

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D landing = Physics2D.Raycast(LandingCheck.transform.position, Vector2.down, 0.5f);
        if (isJumping && landing && GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }

    }

    public void OnCrouching(bool isCrouching){

        //animator.SetBool("IsCrouching", isCrouching); 

    }

    void FixedUpdate()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, interacting, jump);

        jump = false;

    }

   void OnCollisionEnter2D(Collision2D other)
   {
       if (other.gameObject.GetComponent<Rigidbody2D>() == null) return;
       
        if (other.gameObject.tag == "Enemy")
        {
        
            gameOver.SetActive(true);
            horizontalMove = 0;
            isDeath = true;
            animator.SetBool("Death", true);
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
            animator.SetBool("Death", true);
            print("Impaled");
        }

        if (other.tag == "Water")
        {
            gameOver.SetActive(true);
            horizontalMove = 0;
            isDeath = true;
            animator.SetBool("Death", true);
            print("Drowned");
        }

    }

    public void FootStep(){

        walkSound.Play();
    }

}
