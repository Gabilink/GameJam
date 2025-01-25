using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class GameControler : MonoBehaviour
{
    private static GameControler instance;
    public static GameControler GetInstance() { return instance; }

    //COMBOS
    private int puntuacion;
    private bool previousCombo;

    #region Player
    private GameObject playerGO;
    //controlador de player cuando lo cree yori
    #endregion

    #region Estados de juego
    private bool gameOver;
    public bool GetGameOver() { return gameOver; }
    public void SetGameOver(bool value) { gameOver = value; }

    private bool gameWin;
    public bool GetGameWin() { return gameWin; }
    public void SetGameWin(bool value) { gameWin = value; }

    private bool gamePause;
    public bool GetGamePause() { return gamePause; }
    public void SetGamePause(bool value) { gamePause = value; }
    #endregion

    #region UI
    [Header("UI")]
    [Space(10)]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private GameObject gamePauseUI;
    #endregion

    void Start()
    {
        instance = this;

        playerGO = GameObject.FindGameObjectWithTag("Player");
        //pillar el player cuando lo cree yori

        puntuacion = 0;
        previousCombo = false;
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetGamePause(!GetGamePause());
        }
    }

    private void Update()
    {
        if(gamePause)
        {
            //detener jugador
            //detener enemigos
            //detener tiempo
            //mostrar menu de pausa
        }
    }
    public void Puntuacion(int combo) //Hay puntos positivos por limpiar y negativos cuando los enemigos vuelven a ensuciar
    {
        if(combo>0)
        {
           if(previousCombo)
            {
                puntuacion += (combo * 2);
            }
           if(!previousCombo)
            {
                puntuacion += combo;
                previousCombo = true;
            }
        }
        if(combo<0)
        {
            previousCombo = false;
            puntuacion += combo;
        }
    }
}