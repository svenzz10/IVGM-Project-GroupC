using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ZiplinePlayerInteractions : MonoBehaviour
{
    
    private PlayerCharacterController playerCharCont;
    private float TimeSince = 1;
    public float TimeBetween = 10f;
    public float SlowFallTime = 0f;
    public GameObject HeldZip;
    public bool zipVisible = false;
    public GameObject UIStart;
    public GameObject PickupHUD;

   

    // Start is called before the first frame update
    void Start()
    {
         playerCharCont = GetComponent<PlayerCharacterController>();
        HeldZip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            //This starts zipping when E is pressed, the player is in the right position and has the powerup
         if (playerCharCont.HasZiphook == true && playerCharCont.WithinZipTrigger == true && Input.GetKeyDown(KeyCode.F) && playerCharCont.IsZipping == false) 
        {
            Debug.Log("Zipping working");
            playerCharCont.IsZipping = true;
            TimeSince = TimeBetween;
            playerCharCont.movementSharpnessOnGround = 1;
            playerCharCont.accelerationSpeedInAir = 0.1f;
            playerCharCont.gravityDownForce = 0f;
            playerCharCont.characterVelocity = new Vector3(0f, 0f, 0f);

        }

         if(playerCharCont.IsZipping == true && Input.GetKeyDown(KeyCode.F) && TimeSince<5)
        {
            playerCharCont.IsZipping = false;
            playerCharCont.movementSharpnessOnGround = 15;
            playerCharCont.accelerationSpeedInAir = 25f;
            playerCharCont.gravityDownForce = 20f;
            SlowFallTime = 50f;
            zipVisible = (true);

        }

        while (playerCharCont.IsZipping == true && zipVisible == true)
        {
            HeldZip.SetActive(false);
            zipVisible = false;
            Debug.Log("It's finding something");
        }

        if(playerCharCont.IsZipping == false && zipVisible == false && playerCharCont.HasZiphook == true)
        {
            zipVisible = true;
            HeldZip.SetActive(true);
        }

        if (UIStart.active == true && Input.GetKeyDown(KeyCode.E))
            UIStart.SetActive(false);

        if (PickupHUD.active == true && Input.GetKeyDown(KeyCode.E))
            PickupHUD.SetActive(false);

        //This makes it so a double-click is ignored for TimeSince frames
        while (playerCharCont.IsZipping == true && TimeSince >= 0)
        {
            TimeSince--;
        }
      /*  if (SlowFallTime >= 0)
        {
            playerCharCont.maxSpeedInAir = 5f;
            Debug.Log("Slow Fall");
        }
        else
        {
            SlowFallTime--;
            Debug.Log("Reducing Slow Fall");
        }
        if (SlowFallTime <= 0)
        {
            playerCharCont.maxSpeedInAir = 10f;
            Debug.Log("Slow Fall"); 
      */
        }
    }
        //set the character's movement speed to disable movement, right now this literally crashes unity
        /* while (playerCharCont.IsZipping == true)
        {
            playerCharCont.movementSharpnessOnGround = 1;
            playerCharCont.accelerationSpeedInAir = 1;
        }*/
    

