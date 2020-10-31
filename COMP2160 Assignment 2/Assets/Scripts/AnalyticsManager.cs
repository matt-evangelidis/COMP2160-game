using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
	public TimeDisplay time;
	
    // Start is called before the first frame update
    void Start()
    {
        AnalyticsEvent.GameStart();
    }
	
	public void PlayerDied(Vector3 deathPosition, string killingObject)
	{
		String timeText = String.Format("{0:D2}:{1:D2}:{2:D2}", time.Timer.Minutes, time.Timer.Seconds, time.Timer.Milliseconds);
		Dictionary<string, object> DeathInfo = new Dictionary<string, object>()
		{
			{"TimeSinceStart", timeText},
			{"DeathPosition", deathPosition},
			{"KillingObject", killingObject}
		};
		
		foreach(KeyValuePair<string, object> kvp in DeathInfo)
		{
			Debug.Log(kvp.Key + ": " + kvp.Value);
		}
		
		Analytics.CustomEvent("PlayerDied", DeathInfo);
	}
	
	public void CheckpointReached(float currentPlayerHP)
	{
		String timeText = String.Format("{0:D2}:{1:D2}:{2:D2}", time.Timer.Minutes, time.Timer.Seconds, time.Timer.Milliseconds);
		Dictionary<string, object> CheckpointInfo = new Dictionary<string, object>()
		{
			{"TimeSinceStart", timeText},
			{"CurrentHP", currentPlayerHP}
		};
		
		foreach(KeyValuePair<string, object> kvp in CheckpointInfo)
		{
			Debug.Log(kvp.Key + ": " + kvp.Value);
		}
		
		Analytics.CustomEvent("CheckpointReached", CheckpointInfo);
	}
	
	public void GameOver()
	{
		AnalyticsEvent.GameOver();
		Debug.Log("Game Over");
	}
}
