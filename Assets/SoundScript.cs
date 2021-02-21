using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip fire;
    public static AudioClip Expl;
    //public static AudioClip Thrust;
    static AudioSource audioSou;
    // Start is called before the first frame update
    void Start()
    {
        fire = Resources.Load<AudioClip>("Gun");
        Expl = Resources.Load<AudioClip>("Explosion");
        //Thrust = Resources.Load<AudioClip>("THRUST");
        audioSou = GetComponent<AudioSource>();
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound ( string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSou.PlayOneShot(fire);
                audioSou.volume = 0.5f;
                break;
            case "Expl":
                audioSou.PlayOneShot(Expl);
                break;
            
        }
    }
}
