using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] checkpointArray;
    private Checkpoint currentCheckPoint;
    private int counter = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentCheckPoint.Current)
        {
            NextCheckpoint();
        }
    }

    /*    public static void HitCheckPoint(Checkpoint checkpoint)
        {
            if (checkpoint.Current)
            {
                checkpoint.TimeStored = Time.time;
                Debug.Log("Checkpoint Hit At Time: " + checkpoint.TimeStored);
                checkpoint.Current = false;
            }
        }*/

    public void SetCheckpoint()
    {
        checkpointArray[counter].Current = true;
        currentCheckPoint = checkpointArray[counter];
        currentCheckPoint.SetGlow();
    }

    public void NextCheckpoint()
    {
        if (counter >= checkpointArray.Length)
        {
            Debug.Log("Counter: " + counter);
            FindObjectOfType<MenuHandler>().GameOver();
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
