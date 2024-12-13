using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float destroyDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
		// Another form of the Destroy function, which allows us to destroy an object
		// after a delay in seconds. We set the delay with a variable "destroyAfter"
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the game object along the Y-axis (X is 0f), and we make the Y value into 
        // a variable so we can change the direction (up or down) and make the script reusable
        // in different situations. (can do the same for X and then it'll move in any direction you want)
        Vector3 translationVector = new Vector3(0f, 1f) * moveSpeed * Time.deltaTime;
        transform.Translate(translationVector);
    }
}
