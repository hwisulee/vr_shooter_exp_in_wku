using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgmusic : MonoBehaviour
{
    public AudioClip[] music;
    AudioSource audioSource;

    string Date;
    string[] temp;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MyListener(bool isOn)
    {
        if (isOn)
        {
            StartCoroutine("Playlist");
        }
        else
        {
            audioSource.Stop();
            StopCoroutine("Playlist");
        }
    }

    IEnumerator Playlist()
    {
        audioSource.clip = music[0];
        audioSource.Play();

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Date = DateTime.Now.ToString("MM dd");

            temp = Date.Split(" ");

            if (temp[0].Equals("10"))
            {
                // 할로윈 음악 재생
                audioSource.clip = music[1];
                audioSource.Play();
                audioSource.loop = true;
            }

            if (temp[0].Equals("12"))
            {
                int tempdd = int.Parse(temp[1]);

                if (tempdd >= 1 && tempdd <= 25)
                {
                    // 크리스마스 음악 재생
                    audioSource.clip = music[0];
                    audioSource.Play();
                    audioSource.loop = true;
                }
            }
        }
    }
}
