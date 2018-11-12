using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    //PUBLIC VARIABLES
    //public GameObject playerCamera; //Player Camera for peronal Display
    public Transform bulletSpawnPoint; // spawn point for the bullet
    public GameObject bullet; //Bullet To be Shot
    public Rigidbody rb;
    public float health;

    public string lHor;
    public string lVer;
    public string rHor;
    public string rVer;

    //Private VARIABLES
    [SerializeField]
    float walkingSpeed; //Moving Speed for the player

    GameObject otherPlayer;
    
    Vector3 moveInput;
    Vector3 moveVelocity;

    bool otherPlayerContact; //Set to true when other player has been touched

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (isLocalPlayer)
        {
            //playerCamera.SetActive(false);
            rb = this.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            
        }//End of Camera check
        else
        {
            //playerCamera.SetActive(true);
            rb = this.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }//End of Camera check
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer) //Use IsLocalPlayer in order to let the PC know this is the player controlling this object
        {
            //Movement
            moveInput = new Vector3(Input.GetAxisRaw(lHor), 0f, Input.GetAxisRaw(lVer));
            moveVelocity = moveInput * walkingSpeed;

            //Rotate
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw(rHor) + Vector3.forward * Input.GetAxisRaw(rVer);
            if(playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

          

        }//End of IsLoclPlayer
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            rb.velocity = moveVelocity;
        }
    }

    [Command]
    void CmdShoot()
    {
        GameObject _bullet = (GameObject)Instantiate(bullet.gameObject, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        NetworkServer.SpawnWithClientAuthority(_bullet, connectionToClient);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            otherPlayerContact = true;
            otherPlayer = other.gameObject;
        }//End of Tag"Player" check
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            otherPlayerContact = false;
            otherPlayer = null;
        }//End of Tag"Player" check
    }


    
  
}
