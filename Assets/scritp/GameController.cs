using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    public GameObject cubeInduk; // Induk dari semua cube
    public GameObject finishPanel; // Panel yang muncul saat game selesai
     public TextMeshProUGUI scoreText; // TextMeshPro untuk menampilkan skor

    private CubeTrigger[] cubes; // Daftar semua CubeTrigger
    private int totalCubes; // Total jumlah cube
    private int answeredCubes = 0; // Jumlah cube yang sudah dijawab
    private int score = 0; // Skor awal
    private void Start()
    {
        // Ambil semua CubeTrigger dari anak-anak CubeInduk
        cubes = cubeInduk.GetComponentsInChildren<CubeTrigger>();
        totalCubes = cubes.Length;

         Debug.Log($"Total cubes di CubeInduk: {totalCubes}"); // Debug untuk memastikan jumlah cube benar

        // Pastikan panel selesai tidak aktif
        if (finishPanel != null)
        {
            finishPanel.SetActive(false);
        }
         // Inisialisasi teks skor
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    public void UpdateScore(int amount)
    {
        score += amount;

        // Perbarui teks skor
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void CubeAnswered()
    {
        Debug.Log($"Cube dijawab. Total cube yang sudah dijawab: {answeredCubes + 1} / {totalCubes}");
   
        answeredCubes++;

        // Cek apakah semua cube sudah dijawab
        if (answeredCubes >= totalCubes)
        {
            Debug.Log("Semua soal sudah dijawab! Game selesai!");
            FinishGame();
        }
    }

    private void FinishGame()
    {
        if (finishPanel != null)
        {
            finishPanel.SetActive(true); // Tampilkan panel selesai
        }
    }
}
