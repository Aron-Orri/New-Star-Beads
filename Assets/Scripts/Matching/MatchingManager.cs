
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingManager : MonoBehaviour
{
    enum Shapes { Oval, Triangle, Rectangle, Circle, Square, Diamond, Heart, Star };
    [SerializeField] Sprite[] shapeSprite; // THESE NEED TO BE IN THE SAME ORDER AS THE SHAPES ABOVE
    [SerializeField] private GameObject[] buttons; // The game object of all buttons
    [SerializeField] private Shapes currentLevelShape; // The correct shape for the level
    [SerializeField] private GameObject draggingSystem;

    //Audio variables
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] shapeAudioClips; // The list of autio clips played for specific shapes (needs to be in the same order as sprites)
    [SerializeField] private bool playSoundOnPress = false;
    [SerializeField] private bool playSoundOnCompletion = false;
    [SerializeField] private bool playSoundOnAwake = false;

    private bool[] pressedButtons; // The buttons that are currently pressed
    private Shapes[] buttonShapes; // The shapes assigned to each button
    private bool[] buttonAssigned; // The buttons that have had shapes assigned

    private bool freeze = false;

    void Awake()
    {
        // Setup audio source
        audioSource = GetComponent<AudioSource>();
        if (playSoundOnAwake) PlayShapeSound(currentLevelShape);

        // Setup matching system
        buttonShapes = new Shapes[buttons.Length];
        buttonAssigned = new bool[buttons.Length];
        pressedButtons = new bool[buttons.Length];

        if (buttonShapes.Length < 5 ) 
        {
            Debug.LogError("Not enough buttons for matching system");
            CompleteMatching();
        }

        RandomizeCorrect();
        RandomizeCorrect();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttonAssigned[i]) continue;
            RandomizeIncorrect(i);
        }
        UpdateSprites();
    }

    private void UpdateSprites()
    {
        for (int i = 0;i < buttonShapes.Length;i++)
        {
            buttons[i].GetComponent<Image>().sprite = shapeSprite[(int)buttonShapes[i]];
        }
    }

    private void RandomizeCorrect()
    {
        var idx = Random.Range(0, buttonShapes.Length);
        if (!buttonAssigned[idx])
        {
            buttonShapes[idx] = currentLevelShape;
            buttonAssigned[idx] = true;
        }
        else RandomizeCorrect();
    }

    public void RandomizeIncorrect(int idx)
    {
        Shapes shape = currentLevelShape;
        while (shape == currentLevelShape)
        {
            shape = (Shapes)Random.Range(0, 8);
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttonShapes[i] == shape)
                {
                    shape = currentLevelShape;
                }
            }
            if (shape == currentLevelShape) continue;
            buttonShapes[idx] = shape;
            buttonAssigned[idx] = true;
        }

    }

    public void PressButton(int idx)
    {
        if (freeze) return;

        buttons[idx].GetComponent<Image>().color = Color.black;
        pressedButtons[idx] = true;
        int correct = 0;
        int pressedCount = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (!pressedButtons[i]) continue;
            pressedCount++;
            if (buttonShapes[i] == currentLevelShape)
            {
                correct++;
            }
        }


        if (correct == 2 && pressedCount == 2)
        {
            freeze = true;
            MakePressedColor(Color.green);
            if (playSoundOnCompletion) PlayShapeSound(currentLevelShape);
            Invoke(nameof(CompleteMatching), 1);
        }
        if (pressedCount >= 2 && correct != 2)
        {
            freeze = true;
            Invoke(nameof(Unfreeze), .5f);
            Invoke(nameof(ClearPressed),.45f);
            MakePressedColor(Color.red);
        }

        if (playSoundOnPress) PlayShapeSound(buttonShapes[idx]);
    }

    public void MakePressedColor(Color color)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (pressedButtons[i]) buttons[i].GetComponent<Image>().color = color;
        }
    }

    public void ClearPressed()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            pressedButtons[i] = false;
            buttons[i].GetComponent<Image>().color = Color.white;
        }
    }

    public void Unfreeze()
    {
        freeze = false;
    }

    void CompleteMatching()
    {
        gameObject.SetActive(false);
        draggingSystem.SetActive(true);
    }

    void PlayShapeSound(Shapes shape)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("Audio source of matching system not setup");
            return;
        }
        if (shapeAudioClips[(int)shape] == null)
        {
            Debug.LogWarning("Sound for " + shape + " not setup");
            return;
        }

        audioSource.PlayOneShot(shapeAudioClips[(int)shape]);
    }

    // Returns a list of the buttons that are correct for the current level shape
    public List<GameObject> GetCorrectButtons()
    {
        List<GameObject> correctButtons = new List<GameObject>();
        
        for (int i = 0; i<buttons.Length; i++)
        {
            if (buttonShapes[i] == currentLevelShape)
            {
                correctButtons.Add(buttons[i]);
            }
        }

        return correctButtons;
    }
}
