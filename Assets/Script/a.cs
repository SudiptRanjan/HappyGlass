using UnityEngine;
using System.Collections.Generic;

public class a : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public Rigidbody2D rigidBody;

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;

    float pointsMinDistance = 0.1f;

    Vector2 boxColliderSize;

    public void AddPoint(Vector2 newPoint)
    {

        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        points.Add(newPoint);
        pointsCount++;

        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        if (pointsCount > 1)
        {
            Vector2 previousPoint = points[pointsCount - 2];
            Vector2 direction = newPoint - previousPoint;
            float distance = direction.magnitude;
            Vector2 center = (newPoint + previousPoint) / 2f;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //foreach (BoxCollider2D collider in GetComponents<BoxCollider2D>())
            //{
            //    Destroy(collider);
            //}

            BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.size = new Vector2(distance, boxColliderSize.y);
            boxCollider.offset = center;
            boxCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
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
        boxColliderSize = new Vector2(width, width);
    }
}

