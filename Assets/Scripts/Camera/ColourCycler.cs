using UnityEngine;

public class ColourCycler : MonoBehaviour
{
    public Color[] Colours;
    private int _currentIndex;
    private Camera _cam;
    public bool colourShouldChange;
    public float Speed = 5f;


    void Awake()
    {
        _cam = GetComponent<Camera>();

        _currentIndex = 0;
        _cam.backgroundColor = Colours[_currentIndex];
    }



    public void SetColour(Color colour)
    {
        _cam.backgroundColor = colour;
    }

    public void Cycle()
    {
        colourShouldChange = true;
    }

    void Update()
    {
        if (colourShouldChange)
        {
            var startColour = _cam.backgroundColor;
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
