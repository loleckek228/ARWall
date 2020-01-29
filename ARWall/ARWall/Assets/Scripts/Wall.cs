using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Transform _marker1Position;
    [SerializeField] private Transform _marker2Position;
    [SerializeField] private GameObject _wallPrefab;

    private Vector3 _pointOfMarker1;
    private Vector3 _pointOfMarker2;
    private float wallScaleY = 0.6f;
    private float wallScaleZ = 0.1f;

    public void OnCreateWall()
    {
        _pointOfMarker1 = _marker1Position.position;
        _pointOfMarker2 = _marker2Position.position;

        CreateWall();
    }

    private void CreateWall()
    {
        Vector3 position = Vector3.Lerp(_pointOfMarker1, _pointOfMarker2, 0.5f);

        Quaternion rotation = Quaternion.FromToRotation(Vector3.right, _pointOfMarker1 - _pointOfMarker2);

        float distance = Vector3.Distance(_pointOfMarker1, _pointOfMarker2);

        GameObject wall = Instantiate(_wallPrefab);

        wall.transform.position = position;
        wall.transform.rotation = rotation;
        wall.transform.localScale = new Vector3(distance, wallScaleY, wallScaleZ);
    }
}