using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 10;
    public Image uiPlayer;
    public string playerName;

    [Header("Key Setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode KeyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    [SerializeField]
    Vector3 _resetPosition;

    [SerializeField]
    RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform.GetComponent<RectTransform>();
        _resetPosition = _rectTransform.anchoredPosition;
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        _rectTransform.anchoredPosition = _resetPosition;
        currentPoints = 0;
        UpDateUI();
    }

    void Update()
    {
        if(Input.GetKey(KeyCodeMoveUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        }

        else if(Input.GetKey(KeyCodeMoveDown))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        }
    }

    public void AddPoint()
    {
        currentPoints++;
        CheckMAxPoints();
        UpDateUI();
        Debug.Log(currentPoints);
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void UpDateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMAxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SalvePlayerWin(this);
        }
    }

}
