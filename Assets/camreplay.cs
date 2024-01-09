using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camreplay : MonoBehaviour
{
    Camera thisCam;
    public float delayBetweenFrames = 0.05f;
    private List<Texture2D> frames = new List<Texture2D>();
    private bool isRecording = false;
    private bool isPlaying = false;
    public Renderer quadRenderer;
    private Coroutine playbackCoroutine;
    public targetmove targetmove;


    void Start()
    {
        thisCam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log("I 눌림");
            StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log("O 눌림");
            StopRecording();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Debug.Log("P 눌림");
            StartPlayback();

            Debug.Log(frames.Count);
        }
    }

    void LateUpdate()
    {
        RecordFrame();
    }

    public void StartRecording()
    {
        //frames.Clear(); // "clear" 대신 "Clear"로 수정
        frames = new List<Texture2D>();
        isRecording = true;

    }

    public void StopRecording()
    {
        isRecording = false;

    }

    Texture2D CaptureFrame()
    {
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = thisCam.targetTexture;
        Texture2D frame = new Texture2D(thisCam.targetTexture.width, thisCam.targetTexture.height);
        frame.ReadPixels(new Rect(0, 0, thisCam.targetTexture.width, thisCam.targetTexture.height), 0, 0);
        frame.Apply();
        RenderTexture.active = currentRT;
        return frame;
    }

    void RecordFrame()
    {
        if (isRecording)
        {
            Texture2D frame = CaptureFrame();
            frames.Add(frame);
        }
    }

    IEnumerator Playback()
    {
        isPlaying = true;
        for (int i = 0; i < frames.Count; i++)
        {
            DisplayFrame(frames[i]);
            yield return new WaitForSeconds(delayBetweenFrames); // "delayBetween Frames" 대신 "delayBetweenFrames"로 수정
        }
        isPlaying = false; // "isplaying" 대신 "isPlaying"으로 수정
        Invoke("changenextleveltrue", 0.5f);

    }

    void DisplayFrame(Texture2D frame)
    {
        quadRenderer.material.mainTexture = frame;
    }

    public void StartPlayback()
    {
        if (!isPlaying && frames.Count > 0)
        {
            if (playbackCoroutine != null)
            {
                StopCoroutine(playbackCoroutine);
            }
            playbackCoroutine = StartCoroutine(Playback());
        }
    }

    void changenextleveltrue()
    {
        targetmove.nextlevel = true;
    }
}
