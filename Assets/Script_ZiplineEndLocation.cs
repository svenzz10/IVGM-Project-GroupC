using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ZiplineEndLocation : MonoBehaviour
{

    public GameObject player;
    private PlayerCharacterController playerCharCont;
    Collider triggerZone;

    // Start is called before the first frame update
    void Start()
    {
        triggerZone = GetComponent<Collider>();
        playerCharCont = player.GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider player)
    {
        playerCharCont.IsZipping = false;
        playerCharCont.movementSharpnessOnGround = 15;
        playerCharCont.accelerationSpeedInAir = 25f;
        playerCharCont.gravityDownForce = 20f;
        Debug.Log("EndLocation working");
    }
}
