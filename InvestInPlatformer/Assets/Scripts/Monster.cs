using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] AnimationCurve wiggle;

    float speed = 5f;
    float height = 0.1f;

    Vector3 pos;
    bool checkedPos = false;
    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("GameOver");
            gm.GameOver();
        }
    }

    private void Start()
    {
        checkedPos = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(ActualPos());

        if (gm == null) gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        


    }

    IEnumerator ActualPos()
    {
        checkedPos = false;
        yield return new WaitForSeconds(1f);
        pos = rb.transform.position;

        Debug.Log("pos1: " + pos);
        checkedPos = true;


    }

    void Update()
    {
        if (checkedPos)
        {
            //calculate what the new Y position will be
            float newY = Mathf.Sin(Time.time * speed) * height;
            //set the object's Y to the new calculated Y
            rb.transform.position = new Vector3(pos.x, pos.y + newY, pos.z);

            Debug.Log("pos2: " + rb.transform.position);

            checkedPos = false;
        }

        
    }
}
