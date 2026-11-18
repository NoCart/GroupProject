using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

// Singleton Code adapted from https://discussions.unity.com/t/can-someone-please-explain-to-me-how-singleton-works/531569/2
public class GameManager
{
    public static UnityAction onGameOver;
    public static UnityAction updateBackgroundMusic;
    public static UnityAction onGameWin;
    public static UnityAction updateScore;
    public static UnityAction freezePlayer;

    private static GameManager _instance;

    public static int score = 0;

    public AudioClip song = null;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null) _instance = new GameManager();
            return _instance;
        }
    }

    private GameManager()
    {
    }

    public static void setSong(AudioClip _song)
    {
        Instance.song = _song;
        updateBackgroundMusic.Invoke();
    }

    public static void IncreaseScore(int value)
    {
        score += value;
        updateScore.Invoke();
    }

    public static int getScore()
    {
        return score;
    }
    public static void resetScore()
    {
        score = 0;
    }
}


