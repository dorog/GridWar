using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private Player[] players;
    [SerializeField]
    private Edge[] edges;
    [SerializeField]
    private Field[] fields;
    [SerializeField]
    private TextMeshProUGUI text;

    private int currentPlayerIndex = -1;

    void Start()
    {
        foreach(var edge in edges)
        {
            edge.SubscribeToClickResult(ClickResult);
        }

        SelectNextPlayer();
    }

    private void ClickResult(int gainedPoint)
    {
        if(gainedPoint > 0)
        {
            players[currentPlayerIndex].AddPoint(gainedPoint);
        }
        else
        {
            SelectNextPlayer();
        }
    }

    public void Restart()
    {
        foreach (var field in fields)
        {
            field.ResetField();
        }

        foreach (var edge in edges)
        {
            edge.ResetEdge();
        }

        foreach (var player in players)
        {
            player.ResetPlayer();
        }

        SelectNextPlayer();
    }

    private void SelectNextPlayer()
    {
        currentPlayerIndex = GetNextPlayerIndex();
        Color currentPlayerColor = players[currentPlayerIndex].GetColor();

        text.text = players[currentPlayerIndex].GetName() + "'s turn";
        text.color = currentPlayerColor;

        foreach (var edge in edges)
        {
            edge.SetCurrentColor(currentPlayerColor);
        }
    }

    private int GetNextPlayerIndex()
    {
        if (currentPlayerIndex == players.Length - 1)
        {
            return 0;
        }
        else
        {
            return currentPlayerIndex + 1;
        }
    }
}
