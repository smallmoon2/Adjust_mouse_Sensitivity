using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeback : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isSave = true;
    private float timer = 0f;
    private List<Vector3> originalPosition = new List<Vector3>();
    private float speed = 2f;
    private CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        // Call the SavePosition method with the appropriate boolean value
        SavePosition(isSave);

        // Call the TimeTravel coroutine when a specific condition is met
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TimeTravel());
        }
    }

    void SavePosition(bool start)
    {
        if (start)
        {
            timer += Time.deltaTime;
            if (timer >= 0.05f)
            {
                if (originalPosition.Count < 60) // Save up to 3 seconds of positions
                {
                    originalPosition.Add(transform.position);
                }
                else
                {
                    originalPosition.RemoveAt(0);
                    originalPosition.Add(transform.position);
                }
                timer = 0f;
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator TimeTravel()
    {
        isSave = false;
        for (int i = originalPosition.Count - 1; i >= 0; i--)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition[i], 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        isSave = true;
        canvas.alpha = 0;
    }
}
