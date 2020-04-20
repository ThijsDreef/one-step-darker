using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType {
    RESPAWN,
    WALK,
    INCORRECT_MOVE,
    PUNCH,
    FALL
};

public class SFX : MonoBehaviour {
    public static SFX Instance { get; private set; }
    [SerializeField]
    private AudioClip respawn;
    [SerializeField]
    private AudioClip walk;
    [SerializeField]
    private AudioClip notAMove;
    [SerializeField]
    private AudioClip punch;
    [SerializeField]
    private AudioClip fall;
    // Start is called before the first frame update
    void Start() {
        Instance = this;   
    }
    public void playSound(SoundType type) {
        AudioClip t = null;
        switch (type) {
            case SoundType.RESPAWN:
                t = respawn;
                break;
            case SoundType.WALK:
                t = walk;
                break;
            case SoundType.INCORRECT_MOVE:
                t = notAMove;
                break;
            case SoundType.PUNCH:
                t = punch;
                break;
            case SoundType.FALL:
                t = fall;
                break;
        }
        GetComponent<AudioSource>().PlayOneShot(t);
    }
    
}
