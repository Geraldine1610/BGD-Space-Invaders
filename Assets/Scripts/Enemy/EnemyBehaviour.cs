using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collided");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Triggered");

        if(collision.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            //1) what clip do you play, 2) where do you play it
            AudioSource.PlayClipAtPoint(destructionSFX, transform.position);

            
        }
        
    }
}
