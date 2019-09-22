// Date   : 21.09.2019 07:45
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager main;
    [SerializeField]
    private GameObject waveWarning;
    [SerializeField]
    private GameObject waveTimer;

    private Animator animator;

    private bool shopIsOpen = false;

    private bool gameOver = false;
    private bool endGamePrompt = false;
    private bool menuShown = false;
    
    [SerializeField]
    private GameObject menuScreen;

    [SerializeField]
    private SpawnerManager spawner;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (endGamePrompt || menuShown) {
            # if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Q)) {
                Application.Quit();
            }
            # endif
        }
        # if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleMenu();
        }
        # endif

    }

    public bool ShopIsOpen { get { return shopIsOpen; } }

    public void ToggleWarning(bool show)
    {
        //waveWarning.SetActive(show);
    }

    public void ToggleWaveStartTimer(bool show)
    {
        waveTimer.SetActive(show);
    }

    public void ShowTheEnd()
    {
        animator.SetTrigger("showTheEnd");
        shopIsOpen = true;
        endGamePrompt = true;
    }

    public void ToggleMenu()
    {
        menuShown = !menuShown;
        menuScreen.SetActive(menuShown);
        shopIsOpen = menuShown;
    }

    public void ShowShop()
    {
        if (!gameOver) {
            animator.SetTrigger("showShop");
            shopIsOpen = true;
        }
    }

    public void HideShop()
    {
        animator.SetTrigger("hideShop");
        shopIsOpen = false;
    }

    public void GameOver() {
        animator.SetTrigger("showGameOver");
        shopIsOpen = true;
        spawner.StopEverything();
        Debug.Log("Game over!");
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

}
