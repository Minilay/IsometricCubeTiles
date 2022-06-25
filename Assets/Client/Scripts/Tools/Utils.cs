using UnityEngine;

public static class Utils 
{
    public static float GetDistance(Vector2 a, Vector2 b) =>
        (a - b).magnitude;
    
    public static Vector2 AngleToVector(float angle)
    {
        angle *= Mathf.Deg2Rad;
        
        return new Vector2(
            Mathf.Cos(angle), 
            Mathf.Sin(angle)
        );
    }
    public static Vector2 GetMousePosition(Camera camera) => camera.ScreenToWorldPoint(Input.mousePosition);

    public static Vector2 GetMousePositionOnUI(Transform transform) =>
        transform.InverseTransformPoint(Input.mousePosition);
}
