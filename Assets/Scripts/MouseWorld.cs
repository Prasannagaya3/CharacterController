using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld Instance { get; private set; }

    [SerializeField]
    private LayerMask planeLayerMask;

    private void Awake()
    {
        Instance = this;
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, Instance.planeLayerMask);

        return hit.point;
    }
}
