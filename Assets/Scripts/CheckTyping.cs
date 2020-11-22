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

    private EventInstance instance;
    [EventRef]
    public string fmodEvent;

    private void Start()
    {
        instance = RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
        input.Select();
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
            if(words[currentWord].audioEvent != null) RuntimeManager.PlayOneShot(words[currentWord].audioEvent, new Vector3(0f, 0f, -10f)); //if the variable on the current word is not empty play the sound referenced on the variable
            wordObjs[currentWord].SetActive(false);
            currentWord++;
            ContinueGame(typedWord);
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
}
