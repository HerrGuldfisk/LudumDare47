using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager _instance;
	public static GameManager Instance { get { return _instance; } }

	public static float currentFuel;
	public static float maxFuel = 100;

	public static bool inOrbit;
	private static bool destroyed;

	public bool isRunning;
	public GameObject startScreen;

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

		isRunning = false;
	}


	public static void PlayerDeath()
	{
		if (!destroyed)
		{
			destroyed = true;
		}
	}

	public void OnSpace(InputValue value)
	{
		if(!isRunning && value.Get<float>() == 1)
		{
			isRunning = true;
			startScreen.SetActive(false);
		}
	}
}
