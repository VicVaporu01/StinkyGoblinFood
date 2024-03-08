using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Ui;
    [SerializeField] private PlayerController playerControllerScript;

    [FormerlySerializedAs("Vidas")] public int healthPoints;
    public float tiempo;
    public int score;
    int timerEntero;
    public UnityEvent finDeJuego;
    public UnityEvent pausa;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        score = playerControllerScript.GetScore();
        healthPoints = playerControllerScript.GetHealthPoints();
        tiempo -= Time.deltaTime;
        timerEntero = System.Convert.ToInt32(tiempo);
        Ui.text = $"healthPoints: {healthPoints}\nTiempo: {timerEntero}\nPuntaje: {score}";
        if (healthPoints <= 0 || timerEntero <= 0)
        {
            pantallaFinal();
        }
    }

    public void pausacion()
    {
        Time.timeScale = 0;
        pausa.Invoke();
    }

    public void reanudar()
    {
        Time.timeScale = 1;
    }

    public void cargarEscena(string Nombre)
    {
        SceneManager.LoadScene(Nombre);
    }

    public void pantallaFinal()
    {
        Time.timeScale = 0;
        finDeJuego.Invoke();
    }
}