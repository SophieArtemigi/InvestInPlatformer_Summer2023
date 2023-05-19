using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameManager gm;

    private void Update()
    {
        if (target.position.y > transform.position.y)
        {

          
          //  Debug.Log("Score: " + score);

            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;

            float score = (target.position.y - transform.position.y) * 10f;

            gm.ScoreManager((int)score);
        }
    }

   
}
