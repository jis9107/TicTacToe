using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))] // 이 스크립트가 있는 오브젝트는 Camera를 무조건 가지고 있어야 한다. (없으면 생성, 강제성 부여)
public class CameraController : MonoBehaviour
{
    [SerializeField] private float widthUnit = 6f;

    Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
        camera.orthographicSize = widthUnit / (camera.aspect / 2);
    }
}
