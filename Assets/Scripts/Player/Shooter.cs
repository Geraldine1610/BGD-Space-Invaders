using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
//using UnityEngine.Windows;

public class Shooter : MonoBehaviour
{
    // Reference to the original prefab to instatiate
    public GameObject projectilePrefab;
    
	// Reference to the AudioSource component on the player
	public AudioSource sfxPlayer;

    // Get width of Santa to locate projectile
    public SpriteRenderer playerSprite;
    public float playerSpriteHalfWidth;
    public float playerSpriteQuarterHeight = 0.9f;
    Vector3 projectilePosition;

    public float direction;

    public float rightScreenEdge;
    public float leftScreenEdge;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        float inputHl = Input.GetAxis("Horizontal");
        
        if (inputHl > 0 && transform.position.x < rightScreenEdge - playerSpriteHalfWidth)
        {
            //Santa moves to the right - projectile shows up to the Sprite's right side
            playerSpriteHalfWidth = 1.452f;
        }
        else if (inputHl < 0 && transform.position.x > leftScreenEdge + playerSpriteHalfWidth)
        {
            //Santa moves to the left - projectile shows up to the Sprite's left side
            playerSpriteHalfWidth = -1.452f;
        }

        // We instantiate the prefab at the same position as the player,
        // since this script is on the player GameObject
        projectilePosition = new Vector3(transform.position.x + playerSpriteHalfWidth, transform.position.y + playerSpriteQuarterHeight, transform.position.z);
        Instantiate(projectilePrefab, projectilePosition, Quaternion.identity);
        sfxPlayer.Play();
    }
}
