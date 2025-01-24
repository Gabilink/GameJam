using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDControler : MonoBehaviour
{
    private GameControler gameControler;

    #region Escenas
    [SerializeField] private int mainMenuScene;
    [SerializeField] private int gameOverScene;
    [SerializeField] private int level1;

    #endregion

    private void Start()
    {
        gameControler = GameControler.GetInstance();
    }

    #region Botones
    public void Reanudar()
    {

    }

    public void Reiniciar()
    {
        
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Nivel1()
    {
        SceneManager.LoadScene(level1);
    }

    #endregion

}