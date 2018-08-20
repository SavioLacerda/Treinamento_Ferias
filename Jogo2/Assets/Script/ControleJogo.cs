using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleJogo : MonoBehaviour {

    public GameObject PainelCompleto;
    private bool isPaused = false;
    
    
    public void Pause()
    {
        if (!isPaused)
        {
            PainelCompleto.SetActive(true);
            isPaused = true;
            Camera.main.GetComponent<AudioSource>().Pause();
            Time.timeScale = 0;
        }
        
        else
        {
            PainelCompleto.SetActive(false);
            isPaused = false;
            Camera.main.GetComponent<AudioSource>().UnPause();
            Time.timeScale = 1;

        }
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Continuar()
    {
        Camera.main.GetComponent<AudioSource>().UnPause();
        Time.timeScale = 1;
        PainelCompleto.SetActive(false);

    }
    
    public void Reiniciar()
    {
        SceneManager.LoadScene("Principal");
        PainelCompleto.SetActive(false);
    }

    public void Som()
    {
        
        if (!isPaused)
        {
            AudioListener.volume = 0;
            isPaused = true;
        }

        else
        {
            AudioListener.volume = 1;
            isPaused = false;

        }
    }


}
