using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;

    public GameObject player;

    public GameObject interactable;

    float timeStamp;

    public AudioSource pickupSound;

    private bool hasInteracted;
    private bool hasJumpBoost;
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    // Start is called before the first frame update
    void Start()
    {
        interactable.GetComponent<ParticleSystem>().enableEmission = true;
        pickupSound.Stop();
        hasInteracted = false;
        hasJumpBoost = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < 3f){
            if (Input.GetKeyDown("e")){
                timeStamp = Time.time;
                Debug.Log("Interaction!");
                hasInteracted = true;
                
                transform.Translate(Vector3.up * Time.deltaTime);
            }
        }

        if (hasInteracted){
            interactable.GetComponent<ParticleSystem>().enableEmission = false;
            if (Time.time <= (timeStamp + 1f)){
                transform.Translate(Vector3.up * Time.deltaTime);
            } else {
                interactable.GetComponent<Renderer>().enabled = false;
                pickupSound.loop = false;
                pickupSound.Play();
                //todo give jumpboost
                timeStamp = Time.time;
                player.GetComponent<PlayerCharacterController>().jumpForce = 14f;
                hasJumpBoost = true;
                hasInteracted = false;
            }  
        }
        if (hasJumpBoost){
            if (Time.time >= (timeStamp + 8f)){
                player.GetComponent<PlayerCharacterController>().jumpForce = 8f;
            } 
        }
    }
}
