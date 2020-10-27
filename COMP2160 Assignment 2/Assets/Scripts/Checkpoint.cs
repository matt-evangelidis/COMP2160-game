using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private MeshRenderer mesh;
    public Material glowMaterial;
    public Material regularMaterial;
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


    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (current)
        {
            timeStored = Time.time;
            Debug.Log("Checkpoint Hit At Time: " + timeStored);
            current = false;
            SetRegular();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitCheckPoint();
    }
}
