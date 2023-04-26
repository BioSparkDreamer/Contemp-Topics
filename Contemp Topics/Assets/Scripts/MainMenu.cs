using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Device;
using Application = UnityEngine.Application;

public class MainMenu : MonoBehaviour
{
    public GameObject CreditsBackButton, PlayButton;
    // Start is called before the first frame update
    public AudioSource music;

    private void Start()
    {
        music.Play();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(CreditsBackButton);
    }

    public void CreditsDS()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(PlayButton);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}