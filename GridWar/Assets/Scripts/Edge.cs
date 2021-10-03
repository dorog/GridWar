using System;
using UnityEngine;
using UnityEngine.UI;

public class Edge : MonoBehaviour
{
    [SerializeField]
    private Field[] fields;
    [SerializeField]
    private Image image;

    private bool isClicked = false;
    private Action<int> clickResult;

    private Color currentColor;

    public void Start()
    {
        foreach (var field in fields)
        {
            field.IncreaseCounter();
        }
    }

    public void SubscribeToClickResult(Action<int> method)
    {
        clickResult += method;
    }

    public void SetCurrentColor(Color currentPlayerColor)
    {
        currentColor = currentPlayerColor;
    }

    public void OnClick()
    {
        if(!isClicked)
        {
            Disable();

            CalculateResult();
        }
    }

    private void Disable()
    {
        isClicked = true;
        image.color = currentColor;
    }

    private void CalculateResult()
    {
        int gainedPoints = 0;
        foreach (var field in fields)
        {
            gainedPoints += field.DecreaseCounter(currentColor);
        }

        clickResult?.Invoke(gainedPoints);
    }

    public void ResetEdge()
    {
        isClicked = false;
        image.color = Color.black;

        foreach (var field in fields)
        {
            field.IncreaseCounter();
        }
    }
}
