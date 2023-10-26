using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    public Tap tap;
    public float linePointsMinDistance;
    public float lineWidth;
    public ScreenManage SM;
    public static DrawManager drawManagerInstance;
    public List<Line> linesCreatedList;
    public bool istapOff;
    public Transform pen;
    public Obstricle obstricle;

    #endregion
    #region PRIVATE_VARS

    Line currentLine;
    [SerializeField] 
    int cantDrawOverLayerIndex;
   
    Camera cam;
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        drawManagerInstance = this;
    }
    void Start()
    {
        istapOff = true;
        cam = Camera.main;
        cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
        pen.gameObject.SetActive(false);
    }


    void Update()
    {

        Vector2 penPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        pen.transform.position = penPosition;

        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    Debug.Log("Clicked on the UI");
        //}

        if (SM.inkBar.value > 0)
        {

           

            if (Input.GetMouseButtonDown(0))
            {
                BeginDraw();
                pen.gameObject.SetActive(true);
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("Clicked on the UI");
                }
            }



            if (currentLine != null)
            {
                Draw();

            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    BeginDraw();
        //}
        //if (currentLine != null)
        //{
        //    Draw();
        //}


        if (Input.GetMouseButtonUp(0))
        {
            pen.gameObject.SetActive(false);
            EndDraw();
        }

    }

   
    #endregion


    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void DestroyCreatedLines()
    {
       
        foreach (var linesCreated in linesCreatedList)
        {
            Destroy(linesCreated.gameObject);
           
        }
        linesCreatedList.Clear();
        obstricle.ResetPosition();

    }

    #endregion

    #region PRIVATE_FUNCTIONS

    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();
        linesCreatedList.Add(currentLine);
        
        currentLine.UsePhysics(false);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
        currentLine.SetLineWidth(lineWidth);

    }
    void Draw()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);
        if (hit)
            EndDraw();
        else
            currentLine.AddPoint(mousePosition);
    }

    void EndDraw()
    {
        if (currentLine != null)
        {
            if (currentLine.pointsCount < 2)
            {
                Destroy(currentLine.gameObject);
            }
            else
            {
                currentLine.gameObject.layer = cantDrawOverLayerIndex;
                obstricle.SetPhysicsTrue();
                currentLine.UsePhysics(true);
                currentLine = null;
                if(istapOff)
                tap.ToStartWaterFlow();
                istapOff = false;
            }
        }
    }
    #endregion
}
