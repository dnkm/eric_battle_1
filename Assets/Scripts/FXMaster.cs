using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageNumbersPro;
public class FXMaster : MonoBehaviour
{
    [SerializeField]
    public DamageNumber numberPrefab;
    [SerializeField]
    private GameObject SwordEffect;
    [SerializeField]
    private GameObject ArrowEffect;
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
    
    public void Sword(Transform _transform, int direction, float damage)
    {
        if(_transform == null) return;
        DamageNumber damageNumber = numberPrefab.Spawn(_transform.position, damage);
        GameObject effect = Instantiate(SwordEffect, _transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(.5f * direction, .5f, .5f);
        Destroy(effect, 0.5f);
    }
    
    public void Arrow(Transform _transform, int direction, float damage)
    {
        if(_transform == null) return;
        DamageNumber damageNumber = numberPrefab.Spawn(_transform.position, damage);
        GameObject effect = Instantiate(ArrowEffect, _transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(1.5f * direction, 1.5f, 1.5f);
        Destroy(effect, 0.5f);
    }
    
    public void Blood(Transform _transform)
    {
        if(_transform == null) return;
        GameObject effect = Instantiate(BloodEffect, _transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(3f, 3f, 3f);
        Destroy(effect, 0.5f);
    }

    public void PlayAttackAudio()
    {
        if (_audioSource == null) return;
        _audioSource.clip = _baseAttackAudioClip;
        _audioSource.Play();
    }
}
