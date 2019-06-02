using UnityEngine;

public class DistanceToOriginLabel : MonoBehaviour
{
    private void OnGUI()
    {
        // String concatenation is very bad in C#. Use System.Text.StringBuilder
        // for a more performant version of this sort of thing.
        string text = "Distance to Origin: ";
        text += (transform.position.magnitude * 0.001f).ToString("0.0") + "km";
        GUI.Label(new Rect(10, 10, 600, 30), text);
    }
}
