using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ZiplineObjectIs : MonoBehaviour
{

    public Transform startLocationTransform;
    public Transform endLocationTransform;
    public GameObject player;
    public GameObject ZipLight;
    private Material ZipMat;
    private PlayerCharacterController playerCharCont;
    // private Vector3 playerPosition;
    private bool withinLocalTrigger = false;
    private Vector3 direction = new Vector3(0, 0, 0);
    public float ZipSpeed = 0.7f;
    Collider triggerZone;
    
    

    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
        playerCharCont = player.GetComponent<PlayerCharacterController>();
        // playerPosition = player.GetComponent<Transform>().position;
        ZipMat = ZipLight.GetComponent<Renderer>().sharedMaterial;
        Debug.Log(name + " with end loc " + endLocationTransform.name);
        Debug.Log(name + " with start loc " + startLocationTransform.name);
        // Vector3 direction = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //while player is zipping move towards endLocationTransform
        if (withinLocalTrigger == true && playerCharCont.IsZipping == true)
        {
           
            direction = endLocationTransform.position - startLocationTransform.position;
            Debug.Log("subtracting " + endLocationTransform.position + " from " + startLocationTransform.position + " and going in direction " + direction);
            // Debug.Log(endLocationTransform.position);
            // Debug.Log(startLocationTransform.position);

            player.GetComponent<CharacterController>().Move(direction * Time.deltaTime * ZipSpeed);
            

        }
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();

        if (player != null)
        {
            Debug.Log("Enter zipline zone " + name);
            playerCharCont.WithinZipTrigger = true;
            withinLocalTrigger = true;
            ZipMat.EnableKeyword("_EMISSION");
        }
        
   
    }
    void OnTriggerExit(Collider other)
    {
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();

        if (player != null)
        {
            playerCharCont.WithinZipTrigger = false;
            withinLocalTrigger = false;
            playerCharCont.IsZipping = false;
            playerCharCont.movementSharpnessOnGround = 15;
            playerCharCont.accelerationSpeedInAir = 25f;
            playerCharCont.gravityDownForce = 20f;
            Debug.Log("Leaving zipline zone " + name);
            ZipMat.DisableKeyword("_EMISSION");
            direction = new Vector3(0,0,0);
            // Debug.Log(direction);
        }

    }
    
}

