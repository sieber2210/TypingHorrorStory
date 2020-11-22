using UnityEngine;

public class FixBlockToText : MonoBehaviour
{
    public TextMesh textMesh;

    private void Start()
    {
        Bounds textSize = textMesh.GetComponent<Renderer>().bounds;
        transform.localScale = new Vector3(textSize.extents.x * 2f + 2f, textSize.extents.y *2f + 2f, 1f);
    }
}
