using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]  //Reference to Characrer stats scriptable objects
    public CharacterStat PlayerStats;

    [Header("Player Health")] //reference to player health slider UI
    public Slider PlayerHealthBar;
    
    [Header("Player Controller")] //Access to Character component 
    public CharacterController Controller;

    [Header("Player Move Speed")]
    public float MoveSpeed = 10f; //Control speed of player

    [Header("Player Gravity")]
    public float Gravity = -9.81f; //Applys gravity to the velocity of the player on the y-axis

    [Header("Ground Check Object")]
    public Transform GroundCheck; //Reference of ground check object

    [Header("Ground Check Radius")]
    public float GroundDistance = 0.4f; //Sphere radius for ground check

    [Header("Ground Check Layer Mask")]
    public LayerMask GroundMask; //Check what objects the ground check sphere is hitting

    bool IsGrounded; // Check if the player is grounded or not
    Vector3 Velocity; //Stores player current velocity

    [Header("Player Jump Height")] //Player jump height on y axis
    public float JumpHeight = 3f;

    public GameObject LoseScreen;

    public GameObject ThePauseMenu;

    public bool isPause;
    
    void Awake()
    {
        Time.timeScale = 1;
        SetPlayerHealth(); //Run player health function
    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeathCondition(); //run player death condition
        PlayerGroundCheck(); //Player Ground Check
        PlayerMovement(); //Player Movement
        PlayerJumping(); // Player Jumping
        
        
         if (Input.GetButtonDown("Jump") && IsGrounded) //Controls player jumping
         {
             Velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
         }

         if (Input.GetKeyDown(KeyCode.Escape))
         {
             PauseMenu();
         }

         if (Input.GetKey(KeyCode.I))
         {
             Cursor.lockState = CursorLockMode.None;
          
         }
         

         if (Input.GetKeyDown(KeyCode.Q))
         {
             PlayerHealthBar.value -= 25;
         }
         
    }

    private void SetPlayerHealth()
    {
        PlayerHealthBar.value = PlayerStats.characterHealth; //Player health bar/slider = Current character health
    }
    
    private void PlayerDeathCondition() // If player health reaches 0 then die
    {
        if (PlayerHealthBar.value <= 0)
        {
            LoseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void PlayerMovement()
    {
        float X = Input.GetAxis("Horizontal"); // movement on the x axis

        float Z = Input.GetAxis("Vertical"); // movement on the x axis

        Vector3 move = transform.right * X + transform.forward * Z; // Makes the player move 

        Controller.Move(move * MoveSpeed *  Time.deltaTime); // Adding the vector3 "move" into a refercne of the character controller component
    }
    
    private void PlayerGroundCheck()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask); //is grounded us true if the sphere hits any object

        if (IsGrounded && Velocity.y < 0) // Forces player down to the ground 
        {
            Velocity.y = -2f;
        }
    }
    private void PlayerJumping()
    {
        Velocity.y += Gravity * Time.deltaTime; //Adding onto the current velocity on the y-axis

        Controller.Move(Velocity * Time.deltaTime);// Attaches velocity to the player character
    }

    private void PauseMenu()
    {
        isPause = true;
        ThePauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    

}
