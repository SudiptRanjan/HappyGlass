using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class DrawManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    public float linePointsMinDistance;
    public float lineWidth;
    public ScreenManage SM;
    public static DrawManager drawManagerInstance;
    public List<Line> linesCreatedList;
    public bool istapOff;
    public Transform pen;
    public Transform waterDropPosition;

    #endregion
    #region PRIVATE_VARS
    [SerializeField] Vector3 moveDistance;
    [SerializeField] float moveDuration;
    Line currentLine;
    [SerializeField] 
    int cantDrawOverLayerIndex;
    //Vector3 penRotationForward;
    //Vector3 penRotationBackWard;
    Camera cam;
    int count;
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
        //penRotationForward = new Vector3(0, 0, -8f);
        //penRotationBackWard = new Vector3(0, 0, -8f);
        PenRotation();

    }

    void Update()
    {
        ToDrawLine();
        if(istapOff)
        Events.numnerOfWaterDrops(count);
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

    }

    public void  DisablePopUp()
    {
        CancelInvoke("IsGameOver");
        //Debug.Log("Reset");
    }
    public void IsGameOver()
    {
        ScreenManage.instance.GamOverPopUp();
        Debug.Log("game Over");
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero,Quaternion.identity).GetComponent<Line>();
        
        //currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();
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
                linesCreatedList.Add(currentLine);
                currentLine.gameObject.layer = cantDrawOverLayerIndex;
                currentLine.UsePhysics(true);
                currentLine = null;
                if (istapOff)
                
                Events.startWaterFlow();
                istapOff = false;
                if(count <20)
                {
                    //Debug.Log("Print");
                    Invoke("IsGameOver", 10);

                }

            }
        }
    }

    //private void IsGameOver()
    //{
    //    ScreenManage.instance.GamOverPopUp();
    //    Debug.Log("game Over");
    //}
    private void ToDrawLine()
    {
        GameObject thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Vector2 penPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        pen.transform.position = penPosition;

        if (SM.inkBar.value > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {


                if (thisButton != null)//Is click on UI
                {
                  
                    return;
                }
                else
                {
                    BeginDraw();
                    pen.gameObject.SetActive(true);

                }
            }

            if (currentLine != null)
            {
                Draw();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            pen.gameObject.SetActive(false);
            EndDraw();
        }
    }

    
    private void PenRotation()
    {
        //pen.transform.DORotate(penRotationForward, 0.5f).OnComplete(() => { pen.transform.DORotate(penRotationBackWard, 0.05f); }).SetLoops(-1, LoopType.Yoyo);
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.Append(pen.transform.DORotate(moveDistance, moveDuration));
        movementSequence.Append(pen.transform.DORotate(moveDistance, moveDuration));
        movementSequence.SetLoops(-1, LoopType.Yoyo);
        if (movementSequence.IsPlaying()) return;
    }

    #endregion
}
