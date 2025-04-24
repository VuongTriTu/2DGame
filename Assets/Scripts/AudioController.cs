using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public Slider volumeSlider; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Đảm bảo GameObject không bị xóa khi chuyển scene
        _audioSource = GetComponent<AudioSource>();
        volumeSlider.onValueChanged.AddListener(SetVolume); // Đăng ký sự kiện cho Slider
    }

    void Start()
    {
        // Đặt giá trị khởi tạo cho Slider
        if (PlayerPrefs.HasKey("volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("volume");
            volumeSlider.value = savedVolume;
            _audioSource.volume = savedVolume;
        }
        else
        {
            volumeSlider.value = _audioSource.volume;
        }
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
        PlayerPrefs.SetFloat("volume", volume); // Lưu giá trị âm lượng vào PlayerPrefs
    }

    public void PlayMusic()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
