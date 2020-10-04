using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour
{
    public void restartGame()
    {
		GameManager.Instance.dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
