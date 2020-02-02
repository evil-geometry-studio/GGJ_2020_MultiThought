using UnityEngine;

public class ObjDisable : MonoBehaviour
{
    public void DisableObj()
    {
        gameObject.SetActive(false);
    }

    public void PlayFinal()
    {
        Debug.Log("Play final");
        AudioController.Instance.changeTrack(2);
    }
}
