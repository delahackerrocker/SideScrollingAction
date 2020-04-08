using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Link to this GameObject
    public GameObject gameObject;

    protected Vector3 moveRightAmount = new Vector3(.1f, 0, 0);
    protected Vector3 moveLeftAmount = new Vector3(-.1f, 0, 0);

    public void MoveRight()
    {
        // Check if Mario can move right

        // Move Mario to the right
        this.gameObject.transform.position += moveRightAmount;
    }

    public void MoveLeft()
    {
        // Check if Mario can move right

        // Move Mario to the right
        this.gameObject.transform.position += moveLeftAmount;
    }
}