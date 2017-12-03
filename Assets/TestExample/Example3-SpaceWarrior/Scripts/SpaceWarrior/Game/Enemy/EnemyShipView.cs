using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


public class EnemyShipView : PoolableView
{
	private float minSpeed;
	private float maxSpeed;
	private float speed;
	private int health;



	public Signal<EnemyShipView, PlayerShipLaserView, int> LaserHitSignal;



	internal void Init()
	{
		if (LaserHitSignal == null)
		{
			LaserHitSignal = new Signal<EnemyShipView, PlayerShipLaserView, int>();
		}
	}


	internal void Init(int health, float minSpeed, float maxSpeed)
	{
		Init();

		this.speed = Random.Range(minSpeed, maxSpeed);
		this.health = health;

		GetComponent<Rigidbody2D>().velocity = -1 * transform.up * speed;
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
