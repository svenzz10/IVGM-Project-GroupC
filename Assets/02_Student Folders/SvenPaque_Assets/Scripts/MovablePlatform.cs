using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float seconds;

    public bool isMoving = false;

    public Transform platform;

    public GameObject Player;

    PlayerCharacterController pcc;
    CharacterController controller;
    Vector3 platformVelocity = new Vector3(1f, 0f, 0f);

    public float speed;

    public bool reverse;

    private float timeStamp;

    private bool forward = true;

    void Start()
    {
      timeStamp = Time.time; //set timestamp
      if (reverse) forward = false;

      controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    { 
      if (Time.time >= (timeStamp + seconds)){ //check if x seconds have passed
        timeStamp = Time.time; //set new timestamp
        forward = !forward; //change direction
      }

      if (forward){
        platformVelocity = Vector3.forward * speed;
        platform.Translate(platformVelocity * Time.deltaTime);
      } else {
        platformVelocity = -Vector3.forward * speed;
        platform.Translate(platformVelocity * Time.deltaTime);
      }

      if (isMoving){
        if (pcc != null){
          setPlayerPlatformSwitch(true);
          //controller.Move(platformVelocity * Time.deltaTime);

          pcc.platformVelocity = platformVelocity;
        }
      }
    }

    void OnTriggerEnter(Collider collision){
       if (collision.gameObject.name == Player.name){
          Debug.Log("player on platform");
          isMoving = true;
           pcc = collision.gameObject.GetComponent<PlayerCharacterController>();
      }
    }

    void OnTriggerExit(Collider collision){
      if (collision.gameObject.name == Player.name){
          isMoving = false;
          setPlayerPlatformSwitch(false);
          pcc = null;
      }
    }

    void setPlayerPlatformSwitch(bool input){
      pcc.onPlatform = input;
    }
}
