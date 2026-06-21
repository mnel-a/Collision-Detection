using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class CollisionManager : MonoBehaviour
{
    private List<AABB> bounds = new();

    void Start()
    {
        bounds = Object.FindObjectsByType<AABB>().ToList();
    }

    private void Update()
    {
        for (int i = 0; i < bounds.Count; i++)
        {
            AABB box = bounds[i];
            for (int j = 0; j < bounds.Count; j++)
            {
                if (j == i)
                    continue;

                if (IsColliding(box.Bounds, bounds[j].Bounds))
                {
                    box.NotifyCollision(bounds[j]);
                }
            }
        }
    }

    public bool IsColliding(Bounds a, Bounds b)
    {
        return a.min.x <= b.max.x
            && b.min.x <= a.max.x
            && a.min.y <= b.max.y
            && b.min.y <= a.max.y
            && a.min.z <= b.max.z
            && b.min.z <= a.max.z;
    }
}
