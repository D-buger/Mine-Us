using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : SingletonBehavior<PlayManager>
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject newScore;

    public PlayerMove player;
    public UI ui;

    public float depth = 0;

    private float bestPreviousDepth;

    private readonly float minSpeed = 0.05f;
    private readonly float maxSpeed = 1;
    public float speed = 0.05f;
    public float Speed
    {
        get => speed;
        set
        {
            speed = Mathf.Clamp(value, minSpeed, maxSpeed);
        }
    }

    public ObjectPool orePool;
    public SpawnOre spawnOre;

    private float timer = 20;
    public float Timer
    {
        get => timer;
        set
        {
            timer = Mathf.Clamp(value, 0, 20);
        }
    }

    protected override void OnAwake()
    {
        bestPreviousDepth = PlayerPrefs.GetFloat("depth");
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMove>();
        player.playerMoveAction += () => depth += Time.deltaTime * speed * 100;

    }
    private void Update()
    {
        if (depth > bestPreviousDepth)
            newScore.SetActive(true);

        if (timer <= 0)
            GameOver();
        else
            timer -= Time.deltaTime;
    }

    public void TimeStop(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void GameOver()
    {
        if(depth > bestPreviousDepth)
            PlayerPrefs.SetFloat("depth", depth);
        gameOverPanel.SetActive(true);
        TimeStop(0);
    }
}
