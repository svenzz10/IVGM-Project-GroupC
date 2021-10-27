using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUnlimitedBar : MonoBehaviour
{

    public weaponBoosterPickup player;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<weaponBoosterPickup>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.time > 0f)
        {
            image.fillAmount = player.time/10f;
        }
    }
}
