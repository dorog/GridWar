using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private Color color;
    [SerializeField]
    private TextMeshProUGUI text;

    private int point;

    private void Start()
    {
        text.color = color;
        text.text = "0 Point";
    }

    public string GetName()
    {
        return playerName;
    }

    public void AddPoint(int extraPoint)
    {
        point += extraPoint;
        text.text = point + " Point(s)";
    }

    public Color GetColor()
    {
        return color;
    }

    public void ResetPlayer()
    {
        point = 0;
        text.text = point + " Point(s)";
    }
}
