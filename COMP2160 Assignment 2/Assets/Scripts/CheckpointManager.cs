using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] checkpointArray;
    private Checkpoint currentCheckPoint;
    private int counter = 0;
	
	public AnalyticsManager analytics;

    // Start is called before the first frame update
    void Start()
    {
        if (checkpointArray.Length >= 1 || checkpointArray == null)
        {
            SetCheckpoint();
            Debug.Log("Checkpoint(s) Found!");
        }

        else
        {
            Debug.Log("No Checkpoints Found");
        }
		
		analytics = GameObject.Find("/AnalyticsManager").GetComponent<AnalyticsManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the current checkpoint is set to not current, trigger the next checkpoint
        if (!currentCheckPoint.Current)
        {
            NextCheckpoint();
        }
    }

    public Checkpoint[] ReturnCheckpoints()
    {
        return checkpointArray;
    }

    public void NextCheckpoint()
    {
        //if all checkpoints have been hit, trigger GameOver with dead=false
        if (counter >= checkpointArray.Length - 1)
        {
            Debug.Log("Counter: " + counter);
            FindObjectOfType<MenuHandler>().GameOver(false);
            analytics.GameOver();

            enabled = false;
        }

        else if (counter < checkpointArray.Length)
        {
            Debug.Log("Counter: " + counter);

            //increments the counter and sets the next checkpoint fields
            counter++;
            SetCheckpoint();
        }
    }

    public void SetCheckpoint()
    {
        checkpointArray[counter].Current = true;
        currentCheckPoint = checkpointArray[counter];
        currentCheckPoint.SetGlow();
    }
}
