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
        if (!currentCheckPoint.Current)
        {
            NextCheckpoint();
        }
    }

    public Checkpoint[] ReturnCheckpoints()
    {
        return checkpointArray;
    }

    public void SetCheckpoint()
    {
        checkpointArray[counter].Current = true;
        currentCheckPoint = checkpointArray[counter];
        currentCheckPoint.SetGlow();
    }

    public void NextCheckpoint()
    {
        if (counter >= checkpointArray.Length -1)
        {
            Debug.Log("Counter: " + counter);
            FindObjectOfType<MenuHandler>().GameOver(false);
			analytics.GameOver();
			
            gameObject.SetActive(false);
        }

        else if (counter < checkpointArray.Length)
        {
            Debug.Log("Counter: " + counter);
            counter++;
            SetCheckpoint();
        }
    }
}
