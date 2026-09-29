using UnityEngine;

public class coinscript : MonoBehaviour
{
    AudioSource CoinSoundSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CoinSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {
        CoinSoundSource.Play();

        
    }
}
