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
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		if(currentHealth < smokeThreshold)
		{
			// produce smoke
		}
		
		if(currentHealth <= 0)
		{
			// explode and die
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		float collisionPower = collision.impulse.magnitude;
		if(collisionPower > 10f)
		{
			Damage((int)collisionPower);
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
