﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyLifetime = 6f;
    
 
    // Update is called once per frame
    void Update()
    {
        //Countdown timer for left over enemies
        enemyLifetime -= Time.deltaTime;
        if (enemyLifetime <= 0f) {
            Destroy(this.gameObject);
        } 
    }


    // Remove (Destroy) Enemy on hit
    private void OnTriggerEnter(Collider other) {
        if (other.transform.name == "BikeColliderTarget") {
            //Debug.Log("Enemy hit bike");
            Destroy(this.gameObject);
        }
    }
    
 
}
