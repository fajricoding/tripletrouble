using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tombol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PindahSemua(string namaScene){
        SceneManager.LoadScene(namaScene);
    }
    //animasi play
    public void scale(float scale){
        transform.localScale = new Vector2 (1/scale,1*scale);
    }
}