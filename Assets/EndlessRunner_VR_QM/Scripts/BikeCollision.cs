using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); 
    }



    //  Detecting if the bike hit an enemy.   
    void OnTriggerEnter(Collider otherCollider) {
        if (otherCollider.tag == "Enemy") {
            //Debug.Log("You hit " + otherCollider.transform.name);
            player.GetComponent<Player>().speed  += player.GetComponent<Player>().boost;   //Boost speed on hit 
            player.GetComponent<Player>().score++;  //Increment the score counter 

        } else if (otherCollider.tag == "FinishLine") {
            player.GetComponent<Player>().reachedFinishLine = true;
            
        }
    }

}
