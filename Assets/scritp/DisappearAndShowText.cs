using UnityEngine;
using TMPro; // Untuk TextMeshProUGUI

public class DisappearAndShowText : MonoBehaviour
{
    public GameObject textPanel; // Panel UI untuk menampilkan teks soal
    public string questionText;  // Teks soal yang ingin ditampilkan

    private bool playerInRange = false; // Apakah pemain sedang dekat objek

    private static GameObject activeQuestionPanel; // Panel soal yang sedang aktif

    void Start()
    {
        // Pastikan Canvas tidak aktif di awal
        if (textPanel != null)
        {
            textPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Ketika pemain menekan tombol "F" saat mendekati objek
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            DisplayQuestion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Memastikan bahwa objek yang masuk ke trigger adalah pemain
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Saat pemain menjauh dari objek
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Sembunyikan soal hanya jika ini adalah panel yang aktif
            if (textPanel != null && textPanel == activeQuestionPanel)
            {
                textPanel.SetActive(false);
                activeQuestionPanel = null; // Reset panel aktif
            }
        }
    }

    private void DisplayQuestion()
    {
        // Jika sudah ada panel aktif, tutup yang sebelumnya
        if (activeQuestionPanel != null)
        {
            activeQuestionPanel.SetActive(false);
        }

        if (textPanel != null)
        {
            textPanel.SetActive(true);
            activeQuestionPanel = textPanel; // Tandai panel ini sebagai aktif

            // Atur teks soal pada panel UI menggunakan TextMeshProUGUI
            TextMeshProUGUI uiText = textPanel.GetComponentInChildren<TextMeshProUGUI>();
            if (uiText != null)
            {
                uiText.text = questionText; // Set teks soal
            }
        }
    }
}
