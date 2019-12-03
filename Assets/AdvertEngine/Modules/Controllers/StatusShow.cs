using UnityEngine;
using UnityEngine.UI;

public class StatusShow : MonoBehaviour
{
    public static StatusShow instance;

    public Text AdStatusTxt;

    private void Awake()
    {
        instance = this;
    }

    public void ShowAdStatus(string msg)
    {
        AdStatusTxt.text = "\n" + msg + AdStatusTxt.text;
    }
}
