using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject popUpPanel;
    public void OnButtonClick()
    {
        // Add your custom behavior here.
        Debug.Log("Button clicked!");
        popUpPanel.SetActive(false);
    }
}
