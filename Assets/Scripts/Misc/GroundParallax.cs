using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParallax : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform[] grounds;

    private Transform cameraTransform;

    [Header(" Settings ")]
    private float speed = 2f;
    private float groundWidth;

    void Start()
    {
        // Tự tìm cameraTransform
        cameraTransform = Camera.main.transform;

        if (cameraTransform == null)
            Debug.LogError("Không tìm thấy Camera với tag MainCamera!");

        if (grounds.Length > 0 && grounds[0].GetComponent<SpriteRenderer>() != null)
            groundWidth = grounds[0].GetComponent<SpriteRenderer>().bounds.size.x;

        else
            Debug.LogError("Grounds không có SpriteRenderer hoặc mảng grounds trống!");
    }

    void Update()
    {
        foreach (Transform ground in grounds)
            ground.Translate(Vector3.left * speed * Time.deltaTime);

        for (int i = 0; i < grounds.Length; i++)
        {
            if (grounds[i].position.x + groundWidth / 2 < cameraTransform.position.x - Camera.main.orthographicSize * Camera.main.aspect)
            {
                Transform farthestGround = FindFarthestGround();
                grounds[i].position = new Vector3(farthestGround.position.x + groundWidth, grounds[i].position.y, grounds[i].position.z);
            }
        }
    }

    private Transform FindFarthestGround()
    {
        Transform farthestGround = grounds[0];

        foreach (Transform ground in grounds)
            if (ground.position.x > farthestGround.position.x)
                farthestGround = ground;

        return farthestGround;
    }

    public void StopMove()
    {
        speed = 0;
    }
}
