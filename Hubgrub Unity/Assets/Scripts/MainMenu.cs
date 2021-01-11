using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject textReady;
    public GameObject textSet;
    public GameObject textChop;
    public Image axe;
    public GameObject buttons;

    void Start() {
        textReady.SetActive(false);
        textSet.SetActive(false);
        textChop.SetActive(false);
        axe.gameObject.SetActive(false);
        buttons.SetActive(false);

        StartCoroutine(StartTransition(textReady, textSet, textChop, axe, buttons));    
    }

    private IEnumerator StartTransition(GameObject tReady, GameObject tSet, GameObject tChop, Image axe, GameObject buts) {
        WaitForSeconds waitTime = new WaitForSeconds(1f);

        yield return waitTime;
        tReady.SetActive(true);

        yield return waitTime;
        tSet.SetActive(true);

        yield return waitTime;
        tChop.SetActive(true);
        axe.gameObject.SetActive(true);

        yield return waitTime;
        buts.SetActive(true);
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
