using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public AudioSource sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //instantiate: copy the object
        //where do I want it to come out? from the player:
        // the script is on the player, so transform.position
        //gives the player's position
        //third property is rotation. no rotation, that's why:
        //Quaternion.identity (keep it as it is)
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        sfxPlayer.Play();
        
    }
}
