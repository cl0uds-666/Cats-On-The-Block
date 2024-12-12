using UnityEngine;

public class MissionLinepath : MonoBehaviour
{
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLine(Transform[] NewPoints)
    {
        lineRenderer.positionCount = NewPoints.Length;

        for (int i = 0; i < NewPoints.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(NewPoints[i].position.x, NewPoints[i].position.y + 1f, NewPoints[i].position.z));
        }
    }
}
