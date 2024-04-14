using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isDeathPlayer;
    [SerializeField] private ScenesTransition scenesTransition;
    public AudioManager audioManager;
    private void OnEnable()
    {
        scenesTransition.gameObject.SetActive(true);
    }
    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
    }
    public void LoadLevel()
    {
        audioManager.PlaySFX("LoadLevel");
        scenesTransition.LoadLevel();
    }
    public void ResetLevel()
    {
        audioManager.PlaySFX("MissionCompleted");
        scenesTransition.ResetLevel();
    }
}
