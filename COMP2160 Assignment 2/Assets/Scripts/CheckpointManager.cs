using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] checkpointArray;
    private Checkpoint currentCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (checkpointArray.Length >= 1 || checkpointArray == null)
        {
            checkpointArray[0].Current = true;
            currentCheckPoint = checkpointArray[0];
            Debug.Log("Checkpoint(s) Found!");
        }

        else
        {
            Debug.Log("No Checkpoints Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    public void HitCheckPoint(Checkpoint checkpoint)
    {
        if (checkpoint.Current)
        {
            checkpoint.TimeStored = Time.time;
            Debug.Log("Checkpoint Hit At Time: " + checkpoint.TimeStored);
        }
    }*/
}
