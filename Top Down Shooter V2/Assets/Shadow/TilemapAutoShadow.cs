using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(CompositeCollider2D))]
public class ShadowCasterGenerator : MonoBehaviour
{
    void Start()
    {
        var composite = GetComponent<CompositeCollider2D>();

        // Optional: Remove existing shadow casters
        foreach (Transform child in transform)
        {
            if (child.name.StartsWith("ShadowCaster2D"))
                Destroy(child.gameObject);
        }

        for (int i = 0; i < composite.pathCount; i++)
        {
            GameObject shadow = new GameObject("ShadowCaster2D");
            shadow.transform.parent = this.transform;
            shadow.transform.localPosition = Vector3.zero;
            shadow.hideFlags = HideFlags.NotEditable;

            var polygon = shadow.AddComponent<PolygonCollider2D>();

            Vector2[] points = new Vector2[composite.GetPathPointCount(i)];
            composite.GetPath(i, points);
            polygon.SetPath(0, points);

            var sc = shadow.AddComponent<ShadowCaster2D>();
            sc.selfShadows = false;
        }
    }
}
