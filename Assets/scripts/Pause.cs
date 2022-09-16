using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool active;
    public Canvas canvasPause;
    public AudioMixer mixer;
    public Slider slider;
    float lvlAudio;
    public Button[] botonesP;

    public GameObject canvasssssPCarga, canvasssssTrans;

    void Start()
    {
        canvasPause.enabled = false;
        Time.timeScale = 1;
        active = false;
        botonesP = canvasPause.GetComponentsInChildren<Button>();
        slider.interactable = false;
        for (int i = 0; i < botonesP.Length; i++)
        {
            botonesP[i].interactable = false;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Start"))
        {

            active = !active;
            //PlayerPrefs.SetFloat("audio", slider.value);
            //velocidad del juego
            Time.timeScale = (active) ? 0 : 1f;
            canvasPause.enabled = !canvasPause.enabled;
            for (int i = 0; i < botonesP.Length; i++)
            {
                botonesP[i].interactable = !botonesP[i].interactable;
            }
            slider.interactable = !slider.interactable;

            botonesP[0].Select();
        }

    }




    //continuar
    public void play()

    {
        if (active)
        {
            active = !active;
            Time.timeScale = 1;
            PlayerPrefs.SetFloat("audio", slider.value);
            canvasPause.enabled = !canvasPause.enabled;

            for (int i = 0; i < botonesP.Length; i++)
            {
                botonesP[i].interactable = !botonesP[i].interactable;
            }
            slider.interactable = !slider.interactable;
        }
    }

    public void Quit()
    {

        //al menu principal        
        print("quit");
        StartCoroutine(pantallaCarga(0));
        //PlayerPrefs.SetFloat("audio", slider.value);

    }

    //pantalla de carga
    IEnumerator pantallaCarga(int sceneId)
    {
        
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneId);
        while (!op.isDone)
        {

            float progress = Mathf.Clamp01(op.progress / .9f);

            //animacion bucle paginas

            //yield return new WaitForSeconds(2f);

            //librito.GetComponent<Animator>().SetBool("pagsBucle", true);

            print("bla");


            yield return false;
        }

    }
}