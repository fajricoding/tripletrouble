using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UI; // Tambahkan reference untuk InputField
public class CubeTrigger : MonoBehaviour
{
    public GameObject textPanel; // Panel UI untuk menampilkan teks soal
     public TextMeshProUGUI scoreText; // Referensi Text UI untuk menampilkan skor
    public InputField answerInput; // Referensi InputField untuk jawaban pemain
    private int score = 0; // Skor pemain
    private string correctAnswer = "jawabanBenar"; // Jawaban yang benar
    private bool isPlayerNear = false;// Flag untuk memeriksa apakah karakter dekat cube


    private void Start()
    {
        textPanel.SetActive(false); // Pastikan panel soal tidak aktif saat mulai
    }
    private void OnTriggerEnter(Collider other)
    {
        // Periksa apakah objek yang menyentuh adalah karakter
        if (other.CompareTag("Player")) // Pastikan karakter punya tag "Player"
        {
            Debug.Log("Karakter menyentuh cube!");
            // Tambahkan logika lain, misalnya menampilkan soal
             textPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Periksa apakah objek yang keluar dari trigger adalah karakter
        if (other.CompareTag("Player"))
        {
            Debug.Log("Karakter menjauh dari cube!");
            isPlayerNear = false; // Flag menjadi false saat karakter menjauhi cube
            textPanel.SetActive(false); // Nonaktifkan panel soal
        }
    }
    
    public void CheckAnswer()
    {
        if (answerInput.text.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Jawaban benar!");
            score += 20; // Tambah skor jika jawaban benar
        }
        else
        {
            Debug.Log("Jawaban salah!");
            score -= 10; // Kurangi skor jika jawaban salah
        }
        
        UpdateScoreUI(); // Update skor UI
        textPanel.SetActive(false); // Tutup panel soal
    }

    // Method untuk memperbarui skor pada UI
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
