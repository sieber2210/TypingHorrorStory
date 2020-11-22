using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Chapter")]
public class Chapter_SO : ScriptableObject
{
    public int chapterNum;
    public bool lastChapter;
    public Sentence_SO[] sentences;
    public FailedSentence_SO[] failSentences;
}
