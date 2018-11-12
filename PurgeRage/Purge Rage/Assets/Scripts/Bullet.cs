using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float expireRate;


    //PRIVATE VARIABLES
    float currenTimer;

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float damage;

    [SerializeField]
    GameObject otherPlayer;


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        currenTimer += 1 * Time.deltaTime;

        if(currenTimer >= expireRate)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            otherPlayer = other.gameObject;
            DealDamage(otherPlayer);
        }
    }

    public void DealDamage(GameObject otherPlayer)
    {
        otherPlayer.GetComponent<Player>().health -= damage;
        Destroy(this.gameObject);
    }
}
