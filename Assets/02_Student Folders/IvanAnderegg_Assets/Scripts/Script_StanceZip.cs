using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_StanceZip : MonoBehaviour
{
    public GameObject Standing;
    public GameObject Zipping;
    public GameObject Player;
    private PlayerCharacterController playerCharCont;

    // Start is called before the first frame update
    void Start()
    {
        playerCharCont = Player.GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharCont.IsZipping == true)
        {
            Standing.SetActive(false);
            Zipping.SetActive(true);
        }
        else
        {
            Standing.SetActive(true);
            Zipping.SetActive(false);
        }
    }

}
