using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingSys : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera m_camera;
    public GameObject brushRed;
    public GameObject brushOrange;
    public GameObject brushYellow;
    public GameObject brushGreen;
    public GameObject brushBlue;
    public GameObject brushPurple;
    public GameObject brushPink;
    public GameObject brushBrown;

    public int brushCount;

    LineRenderer currentLineRenderer; 

    Vector2 lastPos;

 
    void Update()
    {
       Drawing(); 
    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount -1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }


    void Drawing()
    {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
            if(brushCount == 0)
            {
                CreateBrushRed();
            }
            if(brushCount == 1)
            {
                CreateBrushOrange();
            }
            if(brushCount == 2)
            {
                CreateBrushYellow();
            }
            if(brushCount == 3)
            {
                CreateBrushGreen();
            }
            if(brushCount == 4)
            {
                CreateBrushBlue();
            }
            if(brushCount == 5)
            {
                CreateBrushPurple();
            }
            if(brushCount == 6)
            {
                CreateBrushPink();
            }
            if(brushCount == 7)
            {
                CreateBrushBrown();
            }
            }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    public void redButton()
    {
        brushCount = 0;
    }
    public void orangeButton()
    {
        brushCount = 1;
    }
    public void yellowButton()
    {
        brushCount = 2;
    }
    public void greenButton()
    {
        brushCount = 3;
    }
    public void blueButton()
    {
        brushCount = 4;
    }
    public void purpleButton()
    {
        brushCount = 5;
    }
    public void pinkButton()
    {
        brushCount = 6;
    }
    public void brownButton()
    {
        brushCount = 7;
    }

    void CreateBrushRed()
    {
        GameObject brushInstance = Instantiate(brushRed);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

       void CreateBrushOrange()
    {
        GameObject brushInstance = Instantiate(brushOrange);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

       void CreateBrushYellow()
    {
        GameObject brushInstance = Instantiate(brushYellow);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

       void CreateBrushGreen()
    {
        GameObject brushInstance = Instantiate(brushGreen);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

       void CreateBrushBlue()
    {
        GameObject brushInstance = Instantiate(brushBlue);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

       void CreateBrushPurple()
    {
        GameObject brushInstance = Instantiate(brushPurple);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

       void CreateBrushPink()
    {
        GameObject brushInstance = Instantiate(brushPink);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

       void CreateBrushBrown()
    {
        GameObject brushInstance = Instantiate(brushBrown);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }



}
