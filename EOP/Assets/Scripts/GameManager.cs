using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string transitionedFromScene;

    public Vector2 platformingRespawnPoint;
    public Vector2 respawnPoint;
    [SerializeField] Bench bench;

    public GameObject shade;

    [SerializeField] private FadeUI pauseMenu;
    [SerializeField] private float fadeTime;
    public bool gameIsPaused;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        SaveData.Instance.Initialize();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        if(PlayerController.Instance != null)
        {
            if(PlayerController.Instance.halfMana)
            {
                SaveData.Instance.LoadShadeData();
                if(SaveData.Instance.sceneWithShade == SceneManager.GetActiveScene().name || SaveData.Instance.sceneWithShade == "")
                {
                    Instantiate(shade, SaveData.Instance.shadePos, SaveData.Instance.shadeRot);
                }
            }
        }

        SaveScene();

        DontDestroyOnLoad(gameObject);
        bench = FindFirstObjectByType<Bench>();
    }

    public void SaveScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SaveData.Instance.sceneNames.Add(currentSceneName);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SaveData.Instance.SavePlayerData();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            pauseMenu.FadeUIIn(fadeTime);
            Time.timeScale = 0;
            gameIsPaused = true;
        }
    }
    public void UnpauseGame() 
    {
        Time.timeScale = 1; 
        gameIsPaused = false;
    }

    public void RespawnPlayer()
    {
        SaveData.Instance.LoadBench();

        if(SaveData.Instance.benchSceneName != null) // загрузите сцену benchs, если она существует
        {
            SceneManager.LoadScene(SaveData.Instance.benchSceneName);
        }
        if(SaveData.Instance.benchPos != null) // установите точку возрождения в положение скамейки 
        {
            respawnPoint = SaveData.Instance.benchPos;
        }
        else
        {
            respawnPoint = platformingRespawnPoint;
        }

            PlayerController.Instance.transform.position = respawnPoint;

        StartCoroutine(UIManager.Instance.DectivateDeathScreen());
        PlayerController.Instance.Respawned();
    }
}