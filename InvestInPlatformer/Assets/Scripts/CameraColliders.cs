using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliders : MonoBehaviour
{
    [SerializeField] GameObject deadZone, wallA, wallB;

    float yMin, xMax, xMin;
    Vector3 centrePoint;

    // Start is called before the first frame update
    void Start()
    {
        centrePoint = Camera.main.transform.position;
        yMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        xMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;


        deadZone.transform.position = new Vector3(0f, (yMin - deadZone.GetComponent<BoxCollider2D>().size.y) - 1f, 0f);
        wallA.transform.position = new Vector3(xMin - (wallA.GetComponent<BoxCollider2D>().size.x), centrePoint.y, 0f);
        wallB.transform.position = new Vector3(xMax + (wallB.GetComponent<BoxCollider2D>().size.x), centrePoint.y, 0f);


        deadZone.transform.position = new Vector3(centrePoint.x, (yMin - deadZone.GetComponent<BoxCollider2D>().size.y), 0f);

        
    }

    
}
