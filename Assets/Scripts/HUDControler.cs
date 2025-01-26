using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDControler : MonoBehaviour
{
    private GameControler gameControler;

    private Player_Movement playerScr;

    #region Escenas
    [SerializeField] private int mainMenuScene;
    [SerializeField] private int gameOverScene;
    [SerializeField] private int level1;

    #endregion

    #region StatsJugador
    [Header("Paneles")]
    [SerializeField] private TextMeshProUGUI salud;
    private string saludText;
    private int saludPlayer;

    [SerializeField] private TextMeshProUGUI escudo;
    private string escudoText;
    private int escudoPlayer;

    [SerializeField] private TextMeshProUGUI ammo;
    private string ammoText;
    private int ammoPlayer;

    [SerializeField] private TextMeshProUGUI granadas;
    private string granadasText;
    private int granadasPlayer;
    #endregion

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == mainMenuScene)
        {
            return;
        }
        else
        {

            gameControler = GameControler.GetInstance();
            playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
            saludPlayer = (int)playerScr.GetLife();
            escudoPlayer = playerScr.GetEscudo();
            ammoPlayer = playerScr.GetAmmo();
            granadasPlayer = playerScr.GetGranadas();

            InvokeRepeating("UpdateUI", 0, 1f);
        }
    }

    private void UpdateUI()
    {
        saludPlayer = (int)playerScr.GetLife();
        escudoPlayer = playerScr.GetEscudo();
        ammoPlayer = playerScr.GetAmmo();
        granadasPlayer = playerScr.GetGranadas();

        saludText = saludPlayer.ToString();
        escudoText = escudoPlayer.ToString();
        ammoText = ammoPlayer.ToString();
        granadasText = granadasPlayer.ToString();

        salud.text = saludText;
        escudo.text = escudoText;
        ammo.text = ammoText;
        granadas.text = granadasText;

    }

    #region Botones
    public void Reanudar()
    {
        gameControler.SetGamePause(false);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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