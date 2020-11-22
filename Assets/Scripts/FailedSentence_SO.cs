using UnityEngine;

[CreateAssetMenu(fileName = "New Failed Sentence", menuName = "Failed Sentence")]
public class FailedSentence_SO : ScriptableObject
{
    [TextArea]
    public string failSentence;
}
