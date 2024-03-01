using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlacementManager : MonoBehaviour
{
    enum Shapes { Oval, Triangle, Rectangle, Circle, Square, Diamond, Heart, Star };
    [SerializeField] private Shapes currentLevelShape;
    [SerializeField] private GameObject endScreenObject;
    [SerializeField] private Sprite[] basePlushySprites;
    [SerializeField] private Sprite[] ovalPlushySprites;
    [SerializeField] private Sprite[] trianglePlushySprites;
    [SerializeField] private Sprite[] rectanglePlushySprites;
    [SerializeField] private Sprite[] circlePlushySprites;
    [SerializeField] private Sprite[] squarePlushySprites;
    [SerializeField] private Sprite[] diamondPlushySprites;
    [SerializeField] private Sprite[] heartPlushySprites;
    [SerializeField] private Sprite[] starPlushySprites;
    [SerializeField] private GameObject[] plushieButtons;
    private int selectedPlushy = -1;


    void Start()
    {
        for (int i = 0; i< plushieButtons.Length; i++)
        {
            plushieButtons[i].GetComponent<Image>().sprite = basePlushySprites[i];
        }
    }

    public void handleClick(int idx)
    {
        if (idx < 0 || idx >= plushieButtons.Length) return;
        if (selectedPlushy != -1)
        {
            plushieButtons[selectedPlushy].GetComponent<Image>().sprite = basePlushySprites[selectedPlushy];
        }

        selectedPlushy = idx;

        switch (currentLevelShape)
        {
            case Shapes.Oval:
                plushieButtons[idx].GetComponent<Image>().sprite = ovalPlushySprites[idx];
                break;
            case Shapes.Triangle:
                plushieButtons[idx].GetComponent<Image>().sprite = trianglePlushySprites[idx];
                break;
            case Shapes.Rectangle:
                plushieButtons[idx].GetComponent<Image>().sprite = rectanglePlushySprites[idx];
                break;
            case Shapes.Circle:
                plushieButtons[idx].GetComponent<Image>().sprite = circlePlushySprites[idx];
                break;
            case Shapes.Square:
                plushieButtons[idx].GetComponent<Image>().sprite = squarePlushySprites[idx];
                break;
            case Shapes.Diamond:
                plushieButtons[idx].GetComponent<Image>().sprite = diamondPlushySprites[idx];
                break;
            case Shapes.Heart:
                plushieButtons[idx].GetComponent<Image>().sprite = heartPlushySprites[idx];
                break;
            case Shapes.Star:
                plushieButtons[idx].GetComponent<Image>().sprite = starPlushySprites[idx];
                break;

        }
    }

    public void confirmChoice()
    {
        endScreenObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
