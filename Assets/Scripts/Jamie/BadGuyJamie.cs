using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyJamie : MonoBehaviour
{
    protected int currentAnimationFrame = 0;
    public Sprite[] standingLeft;
    public Sprite[] standingCharge;
    public Sprite[] standingBlast;
    public Sprite[] chargeLeft;
    public Sprite[] blastLeft;
    public float fireRate = .25f;
    public float weaponRange = 50f;

    [HideInInspector] public Movement currentGear = Movement.NOTHING;

    protected Vector3 chargeLeftAmount = new Vector3(.03f, 0, 0);
    protected Vector3 blastLeftAmount = new Vector3(-.03f, 0, 0);
    private void Start()
    {
        currentGear = Movement.STANDING_LEFT;
    }
    public void ChargeLeft()
    {
        // Charge Goku to the left
        this.gameObject.transform.position += chargeLeftAmount;

        // update Goku sprite
        this.gameObject.GetComponent<SpriteRenderer>().sprite = chargeLeft[currentAnimationFrame];
        currentAnimationFrame++;

        if (currentAnimationFrame >= chargeLeft.Length) currentAnimationFrame = 0;
    }

    public void BlastLeft()
    {
        // Make Goku shoot blast
        this.gameObject.transform.position += blastLeftAmount;

        // update Goku sprite
        this.gameObject.GetComponent<SpriteRenderer>().sprite = blastLeft[currentAnimationFrame];
        currentAnimationFrame++;

        if (currentAnimationFrame >= blastLeft.Length) currentAnimationFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGear == Movement.STANDING_LEFT)
        {
            ChargeLeft();
        }
        else if (currentGear == Movement.STANDING_BLAST)
        {
            BlastLeft();
        }
    }
}