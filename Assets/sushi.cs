using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushi : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // Speed of the object
    public Transform target; // The target position to move towards
    public Transform pool; // The pool position to return to

    private bool isMoving = true; // Flag to control movement

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);

        }
    }

    private void MoveToPool()
    {
        // Reset the object's position to the pool position
        transform.position = pool.position;

        // Stop further movement
        isMoving = false;
    }

    // This function can be called to start the movement again
    public void StartMoving()
    {
        isMoving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Submission")
        {
            gameObject.SetActive(false);
        }
    }

   
}


