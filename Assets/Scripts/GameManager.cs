using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int gioco { get; private set; }
    //public int Stage { get; private set; }
    public int Lives { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        } 
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        Lives = 1;
        LoadLevel(1);
    }

    private void LoadLevel(int gioco )
    {
       this.gioco = gioco;
       //this.Stage = stage;
        
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        LoadLevel(+ 1);
    }
    public void ResetLevel()
    {
        Lives--;
        if(Lives > 0)
        {
            LoadLevel(gioco);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        NewGame();
    }

}
