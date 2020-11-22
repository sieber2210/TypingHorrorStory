using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ReturnToMenu(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
