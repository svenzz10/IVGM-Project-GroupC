using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ZiplineObject : MonoBehaviour
{

    public GameObject startLocation;
    public GameObject endLocation;
    public Transform startLocationTransform;
    public Transform endLocationTransform;
    public GameObject player;
    public GameObject ZipLight;
    private Material ZipMat;
    [Tooltip("Currently Unused")]
    public float zipSpeed = 1f;
    private PlayerCharacterController playerCharCont;
    private Vector3 playerPosition;
    private bool withinLocalTrigger = false;
    private Vector3 direction;
    Collider triggerZone;
    
    

    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
        playerCharCont = player.GetComponent<PlayerCharacterController>();
        playerPosition = player.GetComponent<Transform>().position;
        ZipMat = ZipLight.GetComponent<Renderer>().sharedMaterial;
        Debug.Log(endLocationTransform.position);
        Debug.Log(startLocationTransform.position);
        Vector3 direction = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //while player is zipping move towards endLocationTransform
        if (withinLocalTrigger == true && playerCharCont.IsZipping == true)
        {
           
            Vector3 direction = endLocationTransform.position - startLocationTransform.position;
            Debug.Log(direction);
            Debug.Log(endLocationTransform.position);
            Debug.Log(startLocationTransform.position);

            player.GetComponent<CharacterController>().Move(direction * Time.deltaTime);
            

        }
    }
    void OnTriggerEnter(Collider player)
    {
        Debug.Log(GetComponent<Transform>());
        playerCharCont.WithinZipTrigger = true;
        withinLocalTrigger = true;
        ZipMat.EnableKeyword("_EMISSION");
   
    }
    void OnTriggerExit(Collider player)
    {
        playerCharCont.WithinZipTrigger = false;
        withinLocalTrigger = false;
        playerCharCont.IsZipping = false;
        playerCharCont.movementSharpnessOnGround = 15;
        playerCharCont.accelerationSpeedInAir = 25f;
        playerCharCont.gravityDownForce = 20f;
        Debug.Log("Left the Local Trigger Zone");
        ZipMat.DisableKeyword("_EMISSION");
        Vector3 direction = new Vector3(0,0,0);
        Debug.Log(direction);


    }
    
}

