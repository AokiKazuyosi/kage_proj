using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_c : MonoBehaviour
{
    public AudioSource bgm_player_d;
    public AudioSource se_player_d;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void se_play(string se_name)
    {
        se_player_d.clip = Resources.Load<AudioClip>(se_name);
        se_player_d.Play();
    }
}
