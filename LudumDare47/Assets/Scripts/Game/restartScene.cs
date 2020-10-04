using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class restartScene : MonoBehaviour
{
    public void restartGame()
    {
		GameManager.Instance.dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void OnSpace()
	{
		if (GameManager.Instance.dead)
		{
			GameManager.Instance.dead = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			GameManager.Instance.isRunning = false;
		}

	}
}
