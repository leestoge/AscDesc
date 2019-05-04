using UnityEngine;
using UnityEngine.UI;

public class ScoreTextColour : MonoBehaviour
{
    private Text scoreText;
    public Color[] Colours;
    private int _currentIndex;
    private bool colourShouldChange;
    public float Speed = 5f;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        _currentIndex = 0;
        scoreText.color = Colours[_currentIndex];
    }

    public void SetColour(Color colour)
    {
        scoreText.color = colour;
    }

    public void Cycle()
    {
        colourShouldChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (colourShouldChange)
        {
            var startColour = scoreText.color;
            var endColour = Colours[0];

            if (_currentIndex + 1 < Colours.Length)
            {
                endColour = Colours[_currentIndex + 1];
            }

            var newColour = Color.Lerp(startColour, endColour, Time.deltaTime * Speed);

            SetColour(newColour);

            if (newColour == endColour)
            {
                colourShouldChange = false;

                if (_currentIndex + 1 < Colours.Length)
                {
                    _currentIndex++;
                }
                else
                {
                    _currentIndex = 0;
                }
            }
        }
    }
}
