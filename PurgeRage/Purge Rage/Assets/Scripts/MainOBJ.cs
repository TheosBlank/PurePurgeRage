using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainOBJ : NetworkBehaviour
{
    //PUBLIc VARIABLES
    public GameObject playerCamera;
    public GameObject player;


    //PRIVATE VARIABLES
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            playerCamera.SetActive(true);
            rb = player.GetComponent<Rigidbody>();
            player.GetComponent<Player>().rb = rb;
            rb.isKinematic = true;
            
        }
        else
        {
            playerCamera.SetActive(false);
            rb = player.GetComponent<Rigidbody>();
            player.GetComponent<Player>().rb = rb;
            rb.isKinematic = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
