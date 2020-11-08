using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int healthAmount = 10;
    private MeshRenderer mesh;
    public Material glowMaterial;
    public Material regularMaterial;

    private bool hit;
    public bool Hit
    {
        get
        {
            return hit;
        }

        set
        {
            hit = value;
        }
    }

    private bool current;
    public bool Current
    {
        get 
        { 
            return current; 
        }
        
        set 
        { 
            current = value; 
        }
    }

    private float timeStored;
    public float TimeStored
    {
        get 
        { 
            return timeStored;
        }
        
        set 
        { 
            timeStored = value; 
        }
    }
	
	public AnalyticsManager analytics;


    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }
	
	void Start()
	{
		analytics = GameObject.Find("/AnalyticsManager").GetComponent<AnalyticsManager>();
	}

    public void SetGlow()
    {
        mesh.material = glowMaterial;
    }

    public void SetRegular()
    {
        mesh.material = regularMaterial;
    }

    public void HitCheckPoint()
    {
        timeStored = Time.timeSinceLevelLoad;
        Debug.Log("Checkpoint Hit At Time: " + timeStored);
        current = false;
        hit = true;
        SetRegular();
    }

    private void OnTriggerEnter(Collider other)
    {	
		// The player is the only object checkpoints can collide with, so we can safely use GetComponent here without any checks
		if(current)
		{
			// This needs to be recorded here because the analytics task needs the player's current health
			analytics.CheckpointReached(other.gameObject.GetComponent<Health>().CurrentHealth);
			other.gameObject.GetComponent<Health>().Heal(healthAmount);
            
            HitCheckPoint();
		}
		
    }
}
