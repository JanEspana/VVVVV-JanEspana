using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject menu;
    public GameObject player;
    public float playerX, playerY;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            pauseButton = GameObject.Find("PauseButton");
            player = GameObject.Find("Player");

        }
        catch
        {
            player = null;
            pauseButton = null;
        }
        menu = GameObject.Find("Menu");

        playerX = player.GetComponent<Player>().startX;
        playerY = player.GetComponent<Player>().startY;

        menu.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        menu.SetActive(true);
        pauseButton.SetActive(false);
        player.GetComponent<Player>().enabled = false;
    }
    public void ResumeGame()
    {
        menu.SetActive(false);
        pauseButton.SetActive(true);
        player.GetComponent<Player>().enabled = true;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Scene1");
        player.SetActive(true);
        menu.SetActive(false);
        pauseButton.SetActive(true);
        player.GetComponent<Player>().enabled = true;
        player.transform.position = new Vector3(playerX, playerY, 0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
}
