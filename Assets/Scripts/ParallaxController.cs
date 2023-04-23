using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private GameObject playerObj = null;
    private float distanceRatio = 0;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
         if (playerObj == null){
             playerObj = GameObject.Find("Player");
             distanceRatio = 500/(playerObj.transform.position.z - transform.position.z);
        }
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerObj) return;

        transform.position = new Vector3(startPosition.x + (playerObj.transform.position.x / distanceRatio),
                                     startPosition.y + (playerObj.transform.position.y / distanceRatio),
                                     transform.position.z);
    }
}
