using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool current;
    public bool Current
    {
        get { return current; }
        set { current = value; }
    }

    private float timeStored;
    public float TimeStored
    {
        get { return timeStored; }
        set { timeStored = value; }
    }

/*    public void HitCheckPoint()
    {
        if (current)
        {
            timeStored = Time.time;
            Debug.Log("Checkpoint Hit At Time: " + timeStored);
        }
    }*/
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
