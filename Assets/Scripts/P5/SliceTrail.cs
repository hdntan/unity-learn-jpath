using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SliceTrail : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float minDistance = 0.1f;
    private List<Vector3> points = new List<Vector3>();
    private Camera mainCamera;
    public int maxPoints = 15; // Số điểm tối đa của line

    void Start()
    {
         mainCamera = Camera.main;
    lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.positionCount = 0;

    // Độ rộng đầu to, cuối nhỏ
    lineRenderer.widthCurve = new AnimationCurve(
        new Keyframe(0, 0.4f), // đầu nét chém to
        new Keyframe(1, 0.0f)  // cuối nét chém nhỏ
    );

    // Gradient màu trắng sang trong suốt
    Gradient gradient = new Gradient();
    gradient.SetKeys(
        new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
        new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
    );
    lineRenderer.colorGradient = gradient;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            points.Clear();
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

            if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], worldPos) > minDistance)
            {
                // Nếu quá số điểm tối đa, xóa điểm đầu
                if (points.Count >= maxPoints)
                {
                    points.RemoveAt(0);
                    for (int i = 0; i < points.Count; i++)
                    {
                        lineRenderer.SetPosition(i, points[i]);
                    }
                }

                // Kiểm tra va chạm giữa đoạn line mới và target
                if (points.Count > 0)
                {
                    Vector3 lastPoint = points[points.Count - 1];
                    Vector3 dir = worldPos - lastPoint;
                    float dist = dir.magnitude;
                    Ray ray = new Ray(lastPoint, dir.normalized);
                    RaycastHit[] hits = Physics.RaycastAll(ray, dist);
                    foreach (var hit in hits)
                    {
                        Target target = hit.collider.GetComponent<Target>();
                        if (target != null)
                        {
                            // Destroy target như khi click chuột
                            if (target.gameManager.isGameActive)
                            {
                                GameObject.Destroy(target.gameObject);
                                Instantiate(target.explosionParticle, target.transform.position, target.explosionParticle.transform.rotation);
                                target.gameManager.UpdateScore(target.pointValue);
                            }
                        }
                    }
                }

                points.Add(worldPos);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPosition(points.Count - 1, worldPos);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(ClearTrailAfterDelay(0.1f));
        }
    }
    
    IEnumerator ClearTrailAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        lineRenderer.positionCount = 0;
        points.Clear();
    }
}
