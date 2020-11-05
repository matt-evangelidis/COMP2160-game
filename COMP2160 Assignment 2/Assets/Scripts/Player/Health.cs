using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Health : MonoBehaviour
{
	public int maxHealth = 100;
	private int currentHealth;
	public int CurrentHealth
	{
		get
		{
			return currentHealth;
		}
	}
	public int smokeThreshold = 50;

	public ParticleSystem smoke;
	public ParticleSystem explosion;
	
	public AnalyticsManager analytics;
	public MenuHandler menu;

	private bool dead;
	private float timer;
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		analytics = GameObject.Find("/AnalyticsManager").GetComponent<AnalyticsManager>();

		//get particle systems
		smoke = transform.Find("Smoke Effect").GetComponent<ParticleSystem>();
		explosion = transform.Find("Explosion Effect").GetComponent<ParticleSystem>();

		//set delay timer to the duration of the particle system
		timer = explosion.main.duration;

		smoke.Pause();
		explosion.Pause();
	}

    // Update is called once per frame
    void Update()
    {
		if(currentHealth <= smokeThreshold)
		{
			// produce smoke
			smoke.Play();
		}

		if(dead)
		{
			//slight delay timer to allow explosion effect to play before GameOver triggers
			if (timer > 0)
			{
				timer -= Time.deltaTime;
			}
			else
			{
				menu.GameOver(dead);
				GetComponent<Health>().enabled = false;
			}
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		//apply damage to the player
		float collisionPower = collision.impulse.magnitude;
		if(collisionPower > 10f)
		{
			Damage((int)collisionPower);
		}
		
		// This was previously in Update(), but the analytics task needs the name of the collider that killed the player
		if(currentHealth <= 0)
		{
			dead = true;//set death-flag for explosion and reset timer
			explosion.Play();
			analytics.PlayerDied(transform.position, collision.gameObject.name);
		}
	}
	
	public void Heal(int health)
	{
		currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
	}
	
	public void Damage(int damage)
	{
		currentHealth -= damage;
	}
}
