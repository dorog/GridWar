using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private int point = 1;

    private int counter = 0;

    public void IncreaseCounter()
    {
        counter++;
    }

    public int DecreaseCounter(Color color)
    {
        counter--;
        if(counter == 0)
        {
            Disable(color);

            return point;
        }
        else
        {
            return 0;
        }
    }

    private void Disable(Color color)
    {
        image.color = color;
    }

    public void ResetField()
    {
        counter = 0;
        image.color = Color.white;
    }
}
