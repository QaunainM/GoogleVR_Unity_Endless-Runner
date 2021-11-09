using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{

    public GameObject[] roads;   // Array of available roads 
    public Player player;
    public float roadSize;      // Length (Z) of each road

    public float playerOffset = 20f;    // Distance calculator of the player to the road end of the road 
 
    // Update is called once per frame
    void Update()
    {
        // Logic to calculate if the player has gone towards the end of a road  
        foreach (GameObject road in roads) {
            if (player.cameraRig.transform.position.z - road.transform.position.z > playerOffset ) {
                
                // Logic to move the road that has been passed 
                road.transform.position = new Vector3(
                    road.transform.position.x, 
                    road.transform.position.y, 
                    road.transform.position.z + roadSize * roads.Length);  //Moves this road the end position of the array of roads
            }

        }            
       
        
    }
}
