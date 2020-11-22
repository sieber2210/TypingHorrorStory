using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { }

    public void SaveGame(CheckTyping checkTyping)
    {
        SaveSystem.SaveGameData(checkTyping);
    }
}
