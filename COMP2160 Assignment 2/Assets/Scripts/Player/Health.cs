using System.Collections;
using System.Collections.Generic;
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
	public int smokeThreshold;
	
	public AnalyticsManager analytics;
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		analytics = GameObject.Find("/AnalyticsManager").GetComponent<AnalyticsManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth < smokeThreshold)
		{
			// produce smoke
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		float collisionPower = collision.impulse.magnitude;
		if(collisionPower > 10f)
		{
			Damage((int)collisionPower);
		}
		
		// This was previously in Update(), but the analytics task needs the name of the collider that killed the player
		if(currentHealth <= 0)
		{
			//explode and die
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
