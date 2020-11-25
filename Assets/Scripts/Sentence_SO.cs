using UnityEngine;

[CreateAssetMenu(fileName = "New Sentence", menuName = "Sentence")]
public class Sentence_SO : ScriptableObject
{
    public GameObject sentencePrefab;

    [TextArea]
    public string sentence;

}
