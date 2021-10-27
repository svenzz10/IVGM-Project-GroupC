using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBoosterPickup : MonoBehaviour
{

    public WeaponController activeWeapon;
    public AudioSource audioSource;
    public float time = 0f;
    bool off = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        time -= Time.deltaTime;
        if (time <= 0f) {
            if (activeWeapon != null)
            {
                activeWeapon.unlimitedAmmo = false;
            }
            if (off) {
                off = false;
                audioSource.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        PlayerWeaponsManager playerWeaponsManager = other.gameObject.GetComponent<PlayerWeaponsManager>();
        activeWeapon = playerWeaponsManager.GetActiveWeapon();
        if (activeWeapon.name != "Weapon_Blaster(Clone)")
        {
            return;
        }
        activeWeapon.unlimitedAmmo = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        time = 10f;
        audioSource.Play();
        off = true;
    }

}
