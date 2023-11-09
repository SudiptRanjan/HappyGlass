using UnityEngine;
using System.Collections.Generic;


public class Line : MonoBehaviour
{

    #region PUBLIC_VARS
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public Rigidbody2D rigidBody;
    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;
    #endregion
    #region PRIVATE_VARS

    float pointsMinDistance = 0.1f;

    float circleColliderRadius;
    #endregion

    #region UNITY_CALLBACKS
   
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void AddPoint(Vector2 newPoint)
    {
        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        points.Add(newPoint);
        //Debug.Log(pointsCount);
        pointsCount++;
        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = circleColliderRadius;


        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);
       


        if (pointsCount > 1) 
            edgeCollider.points = points.ToArray();

    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }

    public void UsePhysics(bool usePhysics)
    {
        rigidBody.isKinematic = !usePhysics;
    }


    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        circleColliderRadius = width / 2f;

        edgeCollider.edgeRadius = circleColliderRadius;
    }
     
     
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion


}

















