using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyTyrell : MonoBehaviour
{

    protected int currentAnimationFrame = 0;
    public Sprite[] walkingLeft;
    public Sprite[] walkingRight;

    [HideInInspector] public Movement currentGear = Movement.NOTHING;

    protected Vector3 moveRightAmount = new Vector3(.03f, 0, 0);
    protected Vector3 moveLeftAmount = new Vector3(-.03f, 0, 0);

    protected Vector3 tooFarLeft = new Vector3(-8.04f, -3.23f, 0f);
    protected Vector3 tooFarRight = new Vector3(8.04f, -3.23f, 0f);

    private void Start()
    {
        currentGear = Movement.WALKING_RIGHT;
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

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
	
}


public class RayCastWeapon : MonoBehaviour {

	public Transform firePoint;
	public int damage = 40;
	public GameObject impactEffect;
	public LineRenderer lineRenderer;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			StartCoroutine(Shoot());
		}
	}

	IEnumerator Shoot ()
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

		if (hitInfo)
		{
			Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, hitInfo.point);
		} else
		{
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
		}

		lineRenderer.enabled = true;

		yield return 0;

		lineRenderer.enabled = false;
	}
}

