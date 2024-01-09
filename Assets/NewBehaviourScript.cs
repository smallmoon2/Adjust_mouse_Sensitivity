using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update


    // Start is called before the first frame update
    private bool isSlowMotion = false;
    private float originalTimeScale;
    private float originalFixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        originalTimeScale = Time.timeScale;
        originalFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isSlowMotion)
            {
                DoSlowMotion();
                StartCoroutine(ResumeNormalTime());
            }
        }
    }

    public void DoSlowMotion()
    {
        isSlowMotion = true;
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    IEnumerator ResumeNormalTime()
    {
        yield return new WaitForSeconds(0.2f);
        StopSlowMotion();
    }

    public void StopSlowMotion()
    {
        isSlowMotion = false;
        Time.timeScale = originalTimeScale;
        Time.fixedDeltaTime = originalFixedDeltaTime;
    }
}
