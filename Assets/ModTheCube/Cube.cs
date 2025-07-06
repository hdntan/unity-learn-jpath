using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    // Các biến công khai để tùy chỉnh
    public float rotationSpeedX;
    public float rotationSpeedY;
    public float rotationSpeedZ;

    

    void Start()
    {
        // Ngẫu nhiên hóa vị trí trong phạm vi [-5, 5] mỗi trục
        transform.position = new Vector3(
            Random.Range(-5f, 5f),
            Random.Range(1f, 5f),
            Random.Range(-5f, 5f)
        );

        // Ngẫu nhiên hóa kích thước từ 0.5 đến 2 lần
        float scale = Random.Range(0.5f, 2f);
        transform.localScale = Vector3.one * scale;

        // Ngẫu nhiên hóa tốc độ quay trên 3 trục
        rotationSpeedX = Random.Range(10f, 90f);
        rotationSpeedY = Random.Range(10f, 90f);
        rotationSpeedZ = Random.Range(10f, 90f);

        // Ngẫu nhiên hóa màu sắc và độ trong suốt (opacity)
        Color randomColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0.3f, 1f) // Opacity từ 0.3 đến 1
        );

        Material material = Renderer.material;
        material.color = randomColor;
    }

    void Update()
    {
        // Quay Cube liên tục theo các trục X, Y, Z
        transform.Rotate(rotationSpeedX * Time.deltaTime,
                         rotationSpeedY * Time.deltaTime,
                         rotationSpeedZ * Time.deltaTime);

        // Thay đổi màu sắc liên tục theo thời gian giữa đỏ và xanh
        Renderer.material.color = Color.Lerp(
            Color.red,
            Color.blue,
            Mathf.PingPong(Time.time, 1)
        );
    }
}
