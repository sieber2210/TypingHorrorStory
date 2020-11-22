[System.Serializable]
public class SaveData
{
    public int currentChapter;

    public SaveData (CheckTyping checkTyping)
    {
        currentChapter = checkTyping.GetChapter();
    }

    public SaveData(int chapter)
    {
        currentChapter = chapter;
    }
}
