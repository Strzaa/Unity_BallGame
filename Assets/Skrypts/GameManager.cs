using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Ball Settings")]
    public GameObject ballPrefab;
    public Transform startPosition;

    [Header("Time Settings")]
    public TextMeshProUGUI timeText;
    public float time;
    public float slowTimeSeconds;
    public float SlowTimeAmount;

    AudioSource audioSource;
    SoundMenager soundMenager;

    GameObject LevelText;
     
    private void Awake()
    {
        Instantiate(ballPrefab, startPosition.position, Quaternion.identity);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
        soundMenager = GameObject.FindGameObjectWithTag("SoundMenager").GetComponent<SoundMenager>();
        TextLevel(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.Clamp(Mathf.CeilToInt(time), 0, int.MaxValue).ToString();

        if(time <= 0)
        {
            RestartLevel();
        }

        if(Time.timeScale >= 1f && time <= slowTimeSeconds)
        {
            Time.timeScale = SlowTimeAmount;

            timeText.enableVertexGradient = false;
            timeText.color = new Color(1f, 0.2f, 0.2f);

            audioSource.Play();
        }else if (Time.timeScale < 1f && time > slowTimeSeconds)
        {
            Time.timeScale = 1f;
            timeText.enableVertexGradient = true;
            timeText.color = new Color(1f, 1f, 1f);

            audioSource.Stop();
        }


    }

    public void TextLevel(int nr_level)
    {
        switch(nr_level)
        {
            case 0:
                {
                    LevelText = GameObject.FindGameObjectWithTag("Level2").gameObject;
                    LevelText.SetActive(false);
                    break;
                }
            case 1:
                {
                    LevelText = GameObject.FindGameObjectWithTag("Level1").gameObject;
                    LevelText.SetActive(false);
                    break;
                }
            default:
                break;
        }
    }

    public void RestartLevel()
    {
        soundMenager.PlaySound(SoundMenager.Sounds.Lose);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        soundMenager.PlaySound(SoundMenager.Sounds.Win);
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
}
