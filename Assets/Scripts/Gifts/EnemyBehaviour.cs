using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;
    Rigidbody2D gift;
    public float floor = -4.6f;
    bool isFalling = false;
    public BoxCollider2D bagCollider;
    public BoxCollider2D santaCollider;


    
    // physical simulation hits. For Unity to call this function, at least one of the colliding objects
    // needs to have their RigidBody component set to "Dynamic" for Body Type
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("I Collided!");
    }

    // Unity calls this function if the Collider on the game object has "Is Trigger" checked.
	// Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I was triggered!");
        gift = GetComponent<Rigidbody2D>();

        // Check the other colliding object's tag to know if it's
        // indeed a player projectile
        if (collision.tag == "Laser")
        {
            // Make gift fall down after collision
            gift.bodyType = RigidbodyType2D.Dynamic;

            transform.SetParent(null); //disconnect from parent to stop movement in x-direction

            isFalling = true;

            // Destroy the alien game object
            //Destroy(gameObject);

            // Destroy the projectile game object
            Destroy(collision.gameObject);
			
			// Play an audio clip in the scene and not attached to the alien
			// so the sound keeps playing even after it's destroyed
            AudioSource.PlayClipAtPoint(destructionSFX, transform.position);
        }
        

        if (collision.tag == "Santa")
        {
            Debug.Log("santa collision");
            GameObject santaObject = GameObject.FindWithTag("Santa");

            bagCollider = santaObject.GetComponent<BoxCollider2D>();
            gift.velocity = Vector2.zero;
            gift.bodyType = RigidbodyType2D.Kinematic;



        }
    }

    public void Update()
    {
        if (isFalling && gift.transform.position.y >= floor)
        {
            // let fallen gifts stop on the floor once they hit it
            gift.velocity = Vector2.zero;
            gift.bodyType = RigidbodyType2D.Kinematic;
            transform.position = new Vector3(transform.position.x, floor, transform.position.z);

            isFalling = false;
        }
    }
}
