using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] GameManager gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log(collision.tag + ".");
        if(collision.gameObject.tag == "Platform")
        {
           // Debug.Log("Name: " + collision.transform.parent.gameObject.name);
            gm.MovePlatformsUp(collision.transform.parent.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("GameOver");
            gm.GameOver();
        }

    }
}
