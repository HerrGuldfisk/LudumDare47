using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager _instance;
	public static GameManager Instance { get { return _instance; } }

	public static float currentFuel;
	private static bool destroyed;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	public static void PlayerCrash()
	{
		if (!destroyed)
		{
			Debug.Log("Your ship crashed.");
			destroyed = true;
		}
	}
}
