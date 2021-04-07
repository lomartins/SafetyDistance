using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsIA : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start () {
		rb = GetComponent<Rigidbody2D> ();
        rb.AddRelativeForce (Vector2.up * -12);
	}


    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {   
        if(!col.isTrigger){
            //Debug.Log(col.isTrigger + " : " + gameObject.name + " : " + Time.time);
            rb.AddRelativeForce (Vector2.up * -40);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {   
        if(!col.isTrigger){
            //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            rb.AddRelativeForce (Vector2.up * 40);
        }
    }
}