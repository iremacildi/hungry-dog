using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class Timer : MonoBehaviour
{
    private float timeDuration = 3f * 60f;
    private float timer;
    public AudioSource lostAudioSource;

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
    public GameObject pauseMenu;
    public GameObject player;
    private string message1 = "";
    private string message2 = "";
    private bool isWinner = false;
    private bool isLoser = false;
    private float extraTime;

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
        extraTime = player.GetComponent<CollectingFood>().GetExtraTime();
        timer += extraTime;
        player.GetComponent<CollectingFood>().SetExtraTimeZero();

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
            lostAudioSource.Play();
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
        if(!pauseMenu.active)
        {
            if (!isWinner && isLoser)
            {
                GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
                fontSize.fontSize = 120;
                GUI.Label(new Rect(Screen.width / 2 - 330, Screen.height / 2 - 150, 1000, 200), message1, fontSize);
                GUI.Label(new Rect(Screen.width / 2 - 375, Screen.height / 2 + 50, 1600, 200), message2, fontSize);
            }
            else if (isWinner && !isLoser)
            {
                mainCamera.SetActive(false);
                winnerCamera.SetActive(true);
                GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
                fontSize.fontSize = 120;
                GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 150, 1000, 200), "Congrats!", fontSize);
                GUI.Label(new Rect(Screen.width / 2 - 625, Screen.height / 2 + 50, 1600, 200), "You saved your humans.", fontSize);
            }
        } 
    }
}
