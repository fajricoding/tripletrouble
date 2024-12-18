using UnityEngine;
using TMPro;

public class CubeTrigger : MonoBehaviour
{
    public GameObject textPanel; // Panel untuk menampilkan soal
    public TextMeshProUGUI textSoal; // Referensi ke TextSoal
    public TMP_InputField answerInput; // InputField untuk jawaban
    public string soal; // Soal untuk cube ini
    public string correctAnswer; // Jawaban benar untuk cube ini
    public GameController gameController; // Referensi ke GameController

    private bool isAnswered = false; // Menandai apakah cube ini sudah dijawab
    private bool isActiveCube = false; // Apakah cube ini yang sedang diaktifkan

    private void Start()
    {
        textPanel.SetActive(false); // Panel soal tidak aktif saat awal
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAnswered) // Hanya tampil jika belum dijawab
        {
            textPanel.SetActive(true); // Tampilkan panel soal
            textSoal.text = soal; // Tampilkan soal cube ini
            answerInput.text = ""; // Reset input jawaban
            isActiveCube = true; // Tandai cube ini sebagai aktif
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textPanel.SetActive(false); // Sembunyikan panel soal saat pemain menjauh
            isActiveCube = false; // Tandai cube ini sebagai tidak aktif
        }
    }

    public void CheckAnswer()
    {
        if (!isActiveCube) return; // Jangan proses jika bukan cube aktif
        if (isAnswered) return; // Jangan cek jika sudah dijawab

        // Cek jawaban
        if (answerInput.text.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            gameController.UpdateScore(20); // Tambah skor
            Debug.Log("Jawaban benar!");
        }
        else
        {
            gameController.UpdateScore(-10); // Kurangi skor
            Debug.Log("Jawaban salah!");
        }

        isAnswered = true; // Tandai cube ini sebagai sudah dijawab
        textPanel.SetActive(false); // Sembunyikan panel soal
        gameController.CubeAnswered(); // Laporkan ke GameController bahwa cube ini sudah dijawab
        isActiveCube = false; // Nonaktifkan cube ini
    }
}
