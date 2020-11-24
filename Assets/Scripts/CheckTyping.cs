using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class CheckTyping : MonoBehaviour
{
    public BlockSpawner spawner;
    public Failure failure;
    public TMP_InputField input;
    [SerializeField] private int failCountMax = 3;
    [SerializeField] private int winBuildIndex = 7;
    [SerializeField] private int loseBuildIndex = 8;

    List<Sentence_SO> words = new List<Sentence_SO>();
    List<GameObject> wordObjs = new List<GameObject>();
    int currentWord = 0;
    int amountofSentences;
    int chapter;
    bool lastChapter;
    int failCount = 0;

    FMOD.Studio.EventInstance ChapterAudio;
    int num2;

    private void Start()
    {

    }

    private void Update()
    {
        if (currentWord <= amountofSentences && Input.GetKeyDown(KeyCode.Return))
        {
            Checker(input.text, words[currentWord].sentence);
            input.ActivateInputField();
        }
    }

    void Checker(string typedWord, string wordToCheck)
    {
        if (string.Compare(typedWord.ToLower(), wordToCheck.ToLower()) == 0)
        {
            wordObjs[currentWord].SetActive(false);
            currentWord++;
            ContinueGame(typedWord);

            SentenceAudio();
        }
        else if (typedWord.ToLower() == "menu".ToLower())
        {
            SceneManager.LoadScene(0);
        }
        else if (typedWord.ToLower() == "Save Game".ToLower())
        {
            GameManager.Instance.SaveGame(this);
        }
        else 
        {
            Fail();
        }

        input.text = "";
    }

    void ContinueGame(string typedWord)
    {
        if (typedWord.ToLower() == "To continue type this line".ToLower())
        {
            if (!lastChapter)
                SceneManager.LoadScene(chapter + 1);
            else
                SceneManager.LoadScene(winBuildIndex);
        }
    }

    public void SetCurrentWord(Sentence_SO sentence, GameObject wordObject, int _amountOfSentences, int _chapter, bool _lastChapter)
    {
        words.Add(sentence);
        wordObjs.Add(wordObject);

        amountofSentences = _amountOfSentences;
        chapter = _chapter;
        lastChapter = _lastChapter;
    }

    public void RemoveOldWord()
    {
        wordObjs[currentWord].SetActive(false);
        currentWord++;
        Fail();
    }

    void Fail()
    {
        if (failCount <= failCountMax)
        {
            failure.FailedSentence();
            spawner.InstantiateFailSentence(failCount);
            failCount++;
            Test(failCount);
        }
        else
        {
            TotalFail();
        }
    }

    void TotalFail()
    {
        Debug.Log("Total Fail");
        SceneManager.LoadScene(loseBuildIndex);
    }

    void Test(int damageMeter)
    {
        RuntimeManager.StudioSystem.setParameterByName("DamageMeter", 1);
        RuntimeManager.StudioSystem.setParameterByName("DamageLevel", damageMeter);
        RuntimeManager.StudioSystem.setParameterByName("DamageMeter", 0);
        Debug.LogError(damageMeter);
    }

    public int GetChapter()
    {
        return chapter;
    }
    void SentenceAudio()
    {
        string sentNum;
        int num = currentWord + 1;
        sentNum = num.ToString();

        string chapNum;
        int num2 = chapter;
        chapNum = num2.ToString();

        string sentenceNumber = ("event:/Chapter" + chapNum + "/Sentence" + sentNum);
        Debug.Log(sentenceNumber);
        ChapterAudio = FMODUnity.RuntimeManager.CreateInstance(sentenceNumber);
        ChapterAudio.start();
        Debug.Log(chapter);
    }
}
