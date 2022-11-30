using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Camera cam;
    private PlayerController player;
    public TrajectoryController trajectory;
    //private PointerController pointerController;
    [SerializeField] private float pushForce;
    [SerializeField] private bool isDragging;
    [SerializeField] private float distanceMax;
    public GameObject panelEndGame;
    public Button Reload;
    private bool isMoving;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Reload.onClick.AddListener(PlayAgain);

        player = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        cam = Camera.main;
        player.DesactivateRb();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            // if(PlayerController.Instance.isMoving == false)
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }
        if (isDragging)
        {
            OnDrag();
        }

        // if (player.rb.velocity.magnitude <= 0.1f)
        // {
        //     isMoving = false;
        // }
        // else
        // {
        //     isMoving = true;
        // }
    }

    private void OnDragStart()
    {
      //  player.DesactivateRb();
      if (player.rb.velocity.magnitude <= 0.05f)
      {
          startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
          trajectory.Show();
      }
    }

    private void OnDrag()
    {
        if (player.rb.velocity.magnitude <= 0.05f)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            if (distance >= distanceMax)
            {
                distance = distanceMax;
            }
            Debug.Log(distance);
            force = direction * distance * pushForce;

            trajectory.UpdateDots(player.pos, force);
        }
    }

    private void OnDragEnd()
    {
        //  player.ActivateRb();
        if (player.rb.velocity.magnitude <= 0.05f)
        {
            player.Push(force);

            trajectory.Hide();
        }
    }

    public void EndGame()
    {
        panelEndGame.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
