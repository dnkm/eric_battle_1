using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject DamageEffect;
    [SerializeField]
    private GameObject BloodEffect;
    [SerializeField]
    private AudioClip _baseAttackAudioClip;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDamageEffect(int direction)
    {
        GameObject effect = Instantiate(DamageEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(.15f * direction, .15f, .15f);
        Destroy(effect, 0.5f);
    }
    
    public void PlayBloodEffect(int direction)
    {
        GameObject effect = Instantiate(BloodEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(1f * direction, 1f, 1f);
        Destroy(effect, 0.5f);
    }

    public void PlayAttackAudio()
    {
        if(_audioSource == null) return;
        _audioSource.clip = _baseAttackAudioClip;
        _audioSource.Play();
    }
}
