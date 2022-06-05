using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class Timer : MonoBehaviour
{
    private float timeDuration = 4f * 60f;
    private float timer;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI seperator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    private float flashTimer;
    private float flashDuration = 1f;

    private GameObject dragon;
    private GameObject dragonCamera;
    private GameObject winnerCamera;
    private GameObject mainCamera;
    public GameObject player;
    private string message1 = "";
    private string message2 = "";
    private bool isWinner = false;
    private bool isLoser = false;

    void Start()
    {
        Time.timeScale = 1;
        mainCamera = GameObject.Find("MainCamera");
        dragonCamera = GameObject.Find("DragonCamera");
        dragonCamera.SetActive(false);
        winnerCamera = GameObject.Find("WinnerCamera");
        winnerCamera.SetActive(false);
        dragon = GameObject.Find("Dragon");
        dragon.SetActive(false);
        ResetTimer();
    }

    void Update()
    {
        isWinner = player.GetComponent<PlayerMove>().GetIsWin();

        if(!isWinner && timer > 0){
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else{
            Flash();
        }
    }

    private void ResetTimer()
    {
        timer = timeDuration;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if(timer != 0 && !isWinner){
            timer = 0;
            mainCamera.SetActive(false);
            dragonCamera.SetActive(true);
            dragon.SetActive(true);
            message1 = "Time's up! :(";
            message2 = "Dragon is here.";
            isLoser = true;
            UpdateTimerDisplay(timer);
        }

        if(flashTimer <= 0 && !isWinner){
            flashTimer = flashDuration;
        }
        else if(flashTimer >= flashDuration / 2){
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else{
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enabled){
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        seperator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }

    void OnGUI()
    {
        if (!isWinner && isLoser)
        {
            GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
            fontSize.fontSize = 40;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 100), message1, fontSize);
            GUI.Label(new Rect(Screen.width / 2 - 125, Screen.height / 2, 600, 100), message2, fontSize);
        }
        else if (isWinner && !isLoser)
        {
            mainCamera.SetActive(false);
            winnerCamera.SetActive(true);
            GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
            fontSize.fontSize = 40;
            GUI.Label(new Rect(Screen.width / 2 - 85, Screen.height / 2 - 100, 300, 100), "Congrats!", fontSize);
            GUI.Label(new Rect(Screen.width / 2 - 210, Screen.height / 2, 600, 100), "You saved your humans.", fontSize);
        }
    }
}
