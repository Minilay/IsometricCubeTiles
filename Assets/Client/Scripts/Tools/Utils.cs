using UnityEngine;

public static class Utils 
{
    

    public static float GetDistanceBetweenTwoPoints(int x1, int y1, int x2, int y2)
    => Mathf.Sqrt(Mathf.Pow(Mathf.Abs(x1 - x2), 2) + Mathf.Pow(Mathf.Abs(y1 - y2), 2));

    public static float GetDistanceBetweenTwoPoints(Vector2Int a, Vector2Int b) =>
        GetDistanceBetweenTwoPoints(a.x, a.y, b.x, b.y);
    
    public static Vector2 AngleToVector(float angle)
    {
        angle *= Mathf.Deg2Rad;
        
        return new Vector2(
            Mathf.Cos(angle), 
            Mathf.Sin(angle)
        );
    }
    public static Vector2 GetMousePosition(Camera camera) => camera.ScreenToWorldPoint(Input.mousePosition);

    public static void LimitValue(ref float value, float lower, float upper)
    {
        if (value < lower)
            value = lower;
        
        if (value > upper)
            value = upper;
    }
    
}
