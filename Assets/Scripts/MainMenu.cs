using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        string path = Application.persistentDataPath + "/data.dat";
        if (!File.Exists(path))
        {
            return;
        }
        else
        {
            SaveSystem.CreateSaveData();
        }
    }

    public void PlayNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SaveSystem.LoadGameData().currentChapter);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
