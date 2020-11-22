using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Chapter_SO chapter;

    [SerializeField] private float timeBetweenSpawn = 0f;
    private float timer;

    [SerializeField] private bool canSpawn = false;

    private int sentenceCount = 0;

    public CheckTyping typeCheck;

    int sentenceCountMax = 0;

    private int sentencesOnScreen = 0;
    [SerializeField] private int sentencesOnScreenMax = 12;

    private void Start()
    {
        sentenceCountMax = chapter.sentences.Length - 1;
    }

    private void Update()
    {
        if (canSpawn)
        {
            timer += Time.deltaTime;
            if(timer >= timeBetweenSpawn)
            {
                timer = 0f;
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        if (sentenceCount <= sentenceCountMax)
        {
            InstantiateSentence();
            sentenceCount++;
            sentencesOnScreen++;
            if(sentencesOnScreen > sentencesOnScreenMax)
            {
                typeCheck.RemoveOldWord();
            }
        }
        else canSpawn = false;
    }

    void InstantiateSentence()
    {
        GameObject sentence = Instantiate(chapter.sentences[sentenceCount].sentencePrefab, new Vector3(0f, 55f, 0f), Quaternion.identity, transform);
        TextMesh sentenceTextMesh = sentence.GetComponent<TextMesh>();
        sentenceTextMesh.text = chapter.sentences[sentenceCount].sentence;
        typeCheck.SetCurrentWord(chapter.sentences[sentenceCount], sentence, sentenceCountMax, chapter.chapterNum, chapter.lastChapter);
    }

    public void InstantiateFailSentence(int failCount)
    {
        GameObject sentence = Instantiate(chapter.sentences[sentenceCount].sentencePrefab, new Vector3(0f, 55f, 0f), Quaternion.identity, transform);
        TextMesh sentenceTextMesh = sentence.GetComponent<TextMesh>();
        sentenceTextMesh.text = chapter.failSentences[failCount].failSentence;
        typeCheck.SetCurrentWord(chapter.sentences[sentenceCount], sentence, sentenceCountMax, chapter.chapterNum, chapter.lastChapter);
    }
}
