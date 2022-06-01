using UnityEngine;
using Vector2 = UnityEngine.Vector2;

[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Vector2 _defaultPosition; 
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _defaultPosition = transform.position;
    }

    public void SetTileRenderPriority(int x, int y)
    {
        _spriteRenderer.sortingOrder = -(x + y);
    }

    public void ShiftTilesY(float yShift)
    {
        transform.position = _defaultPosition + Vector2.up * yShift;
    }



}
