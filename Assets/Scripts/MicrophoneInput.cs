using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    public string microphone;
    private AudioClip micClip;
    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            microphone = Microphone.devices[0];
            micClip = Microphone.Start(microphone, true, 10, 44100);
        }
        else
        {
            Debug.LogError("No microphone found!");
        }
    }

    public float GetMicrophoneLevel()
    {
        if (micClip == null)
        {
            return 0.0f;
        }

        float[] data = new float[256];
        int micPosition = Microphone.GetPosition(microphone) - 256 + 1;
        if (micPosition < 0)
        {
            return 0.0f;
        }

        micClip.GetData(data, micPosition);
        float levelMax = 0;
        for (int i = 0; i < 256; i++)
        {
            float wavePeak = data[i] * data[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }
}
