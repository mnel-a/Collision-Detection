using UnityEngine;

public class AABB : MonoBehaviour
{
    public float width = 1;
    public float height = 1;
    public float depth = 1;
    public Color debugColor = Color.red;

    private Bounds bounds;

    public Bounds Bounds => bounds;

    void Update()
    {
        bounds = new Bounds(transform.position, new Vector3(width, height, depth));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(transform.position,
            new Vector3(width, height, depth));
    }

    public virtual void NotifyCollision(AABB other)
    {
        Debug.Log($"{name} hit {other.name}");
    }
}