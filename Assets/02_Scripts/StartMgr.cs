using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMgr : MonoBehaviour
{
    [SerializeField] private Rigidbody cameraRb;
    [SerializeField] private Button startBtn;
    [SerializeField] private Image UIImg;
    [SerializeField] private float flashSpeed = 1.0f; // Controls how fast the image flashes (seconds per color)

    private Color normalColor;
    private bool isRed = false;

    void Start()
    {
        cameraRb.useGravity = false;
        normalColor = UIImg.color; // Store the original color

        StartCoroutine(FlashImage()); // Start the coroutine for flashing
        startBtn.onClick.AddListener(() =>
        {
            cameraRb.useGravity = true;
            startBtn.gameObject.transform.localScale = Vector3.zero;
        });
    }

    private IEnumerator FlashImage()
    {
        while (true)
        {
            isRed = !isRed; // Toggle the red flag
            UIImg.color = isRed ? Color.red : normalColor; // Set color based on flag
            yield return new WaitForSeconds(flashSpeed / 2.0f); // Wait half the flash speed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("MarsScene");
    }
}