using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyJamie : MonoBehaviour
{
    protected int currentAnimationFrame = 0;
    public Sprite[] standingLeft;
    public Sprite[] standingCharge;
    public Sprite[] standingBlast;

    [HideInInspector] public Movement currentGear = Movement.NOTHING;

    protected Vector3 moveRightAmount = new Vector3(.03f, 0, 0);
    protected Vector3 moveLeftAmount = new Vector3(-.03f, 0, 0);

    protected Vector3 tooFarLeft = new Vector3(-8.04f, -3.23f, 0f);
    protected Vector3 tooFarRight = new Vector3(8.04f, -3.23f, 0f);

    private void Start()
    {
        currentGear = Movement.STANDING_LEFT;
    }
    public void MoveRight()
    {
        // Move Goomba to the right
        this.gameObject.transform.position += moveRightAmount;

        // update Goomba sprite
        this.gameObject.GetComponent<SpriteRenderer>().sprite = walkingRight[currentAnimationFrame];
        currentAnimationFrame++;

        if (currentAnimationFrame >= walkingRight.Length) currentAnimationFrame = 0;

        // Check if Goomba can move right
        if (this.transform.position.x > tooFarRight.x)
        {
            currentGear = Movement.WALKING_LEFT;
        }
    }

    public void MoveLeft()
    {
        // Move Goomba to the left
        this.gameObject.transform.position += moveLeftAmount;

        // update Goomba sprite
        this.gameObject.GetComponent<SpriteRenderer>().sprite = walkingLeft[currentAnimationFrame];
        currentAnimationFrame++;

        if (currentAnimationFrame >= walkingLeft.Length) currentAnimationFrame = 0;

        // Check if Goomba can move left
        if (this.transform.position.x < tooFarLeft.x)
        {
            currentGear = Movement.WALKING_RIGHT;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGear == Movement.WALKING_RIGHT)
        {
            MoveRight();
        }
        else if (currentGear == Movement.WALKING_LEFT)
        {
            MoveLeft();
        }
    }
}