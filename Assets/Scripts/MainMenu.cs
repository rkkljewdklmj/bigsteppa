using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject Fade;
    public float duration = 3;

   public void PlayGame()
    {

        Fade.SetActive(true);
        StartCoroutine(Fadeout());

    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Fadeout()
    {
        // loop to fade out over 3 seconds
        // Track how many seconds we've been fading.
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;
            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            Fade.GetComponent<CanvasGroup>().alpha = blend;

            // Wait one frame, and repeat.
            yield return null;

           
        } 
        yield return new WaitForSeconds(duration+1);
        
        SceneManager.LoadScene("Level 1");
        //
    }
}
