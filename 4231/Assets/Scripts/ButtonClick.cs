using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public AudioSource buttonPing;
    // Start is called before the first frame update
    void Start()
    {
        buttonPing.Play();
    }
}
