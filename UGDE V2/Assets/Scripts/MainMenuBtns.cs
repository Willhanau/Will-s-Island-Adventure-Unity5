using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof (AudioSource))]
public class MainMenuBtns : MonoBehaviour {

    public GameObject mainScreen;
    public GameObject loadingScreen;
    public GameObject menuOptions;
    public GameObject gameInstructions;

    public AudioClip beep;
    public string levelToLoad;

    public void GameInstructionsOff()
    {
        gameInstructions.SetActive(false);
        menuOptions.SetActive(true);
    }

    public void GameInstructionsOn()
    {
        menuOptions.SetActive(false);
        gameInstructions.SetActive(true);
    }

    public void LoadLevelFromMenu()
    {
        StartCoroutine(LoadLevelFromMenuCoroutine());
    }

    private IEnumerator LoadLevelFromMenuCoroutine()
    {
        PlaySound();
        LoadingScreenOn();
        yield return new WaitForSeconds(3.5f);
        LoadLevel();
    }

    public void LoadingScreenOn()
    {
        mainScreen.SetActive(false);
        loadingScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(beep);
    }

}
