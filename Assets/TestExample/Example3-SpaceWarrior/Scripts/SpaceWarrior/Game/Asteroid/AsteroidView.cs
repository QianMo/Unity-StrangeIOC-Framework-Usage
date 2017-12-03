using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class AsteroidView : PoolableView
{
	private float minSpeed;
	private float maxSpeed;
	private float speed;
	private int health;
	private float rotationSpeed;
	private int rotationDirection;


	public Signal<AsteroidView, PlayerShipLaserView, int> LaserHitSignal;


	internal void Init()
	{
		if (LaserHitSignal == null)
		{
			LaserHitSignal = new Signal<AsteroidView, PlayerShipLaserView, int>();
		}

		rotationSpeed = Random.Range(10, 50);
		rotationDirection = Random.Range(-1f, 1f) < 0 ? -1 : 1;
	}

	internal void Init(int health, float minSpeed, float maxSpeed)
	{
		Init();

		this.speed = Random.Range(minSpeed, maxSpeed);
		this.health = health;

		GetComponent<Rigidbody2D>().velocity = -1 * transform.up * speed;
	}

	void Update()
	{
		transform.Rotate(Vector3.back * rotationDirection * rotationSpeed * Time.deltaTime);
	}


	//Called when the Trigger entered
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PlayerLaser")
		{
			if (health > 0 && GetComponent<OutOfScreenView>().wasInScreen)
			{
				health--;
				LaserHitSignal.Dispatch(this, other.gameObject.GetComponent<PlayerShipLaserView>(), health);
			}
		}
	}
}
