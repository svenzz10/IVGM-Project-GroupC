using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ZiphookPickup : MonoBehaviour
{
    Pickup m_Pickup;
    public GameObject ZipLight;
    private Material ZipMat;
    public GameObject ziphookPrefab;
    public GameObject ziphookPosition;
    private Transform zipTransform;
    public GameObject HeldZiphook;
    public GameObject PickupHUD;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, JetpackPickup>(m_Pickup, this, gameObject);
        ZipMat = ZipLight.GetComponent<Renderer>().sharedMaterial;
        zipTransform = ziphookPosition.transform;

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }


    void OnPicked(PlayerCharacterController player)
    {
       
        if(player && !player.HasZiphook)
        {
            player.HasZiphook = true;
            ZipMat.DisableKeyword("_EMISSION");
            m_Pickup.PlayPickupFeedback();
            Destroy(gameObject);
            HeldZiphook.SetActive(true);
            PickupHUD.SetActive(true);
            // GameObject HeldZiphook = Instantiate(ziphookPrefab, zipTransform);
            

        }
            
        }
    }