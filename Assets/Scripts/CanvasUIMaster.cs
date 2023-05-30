using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIMaster : MonoBehaviour
{
    [SerializeField] private Slider playerSlider;

    [SerializeField] private Slider enemySlider;
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI m_timer;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setPlayerHealthBar(int value, int total)
    {
        playerSlider.value = (float)value / total;
    }

    public void setEnemyHealthBar(int value, int total)
    {
        enemySlider.value = (float)value / total;
    }

    public void updateTimeText(string formattedTime)
    {
        m_timer.text = formattedTime;
    }
}