﻿#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody2D))]
public class BoulderLaunch : MonoBehaviour
{
	[SerializeField] private float speedX;
	[SerializeField] private float upwardForce;
	[SerializeField] private float speedY;
	private float sideForce;

	

	
	private PlayerJump playerJump;
	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
	}

	private void Start()
	{
		if (Input.GetKey(KeyCode.W))
		{
			rb.velocity = transform.up * speedY;
			rb.AddForce(new Vector2(sideForce, 0));
		}
		else if (Input.GetKey(KeyCode.S))
		{
			rb.velocity = -transform.up * speedY;
			rb.AddForce(new Vector2(sideForce, 0));
			playerJump.Jump();
		}
		else
		{
			rb.velocity = transform.right * speedX;
			rb.AddForce(new Vector2(0, upwardForce));
		}
	}

	public void AddToUpwardForce(float force)
	{
		upwardForce += force;
	}

	public void AddToSideForce(float force)
	{
		sideForce += force;
	}


}