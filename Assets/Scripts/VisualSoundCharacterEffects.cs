using UnityEngine;

public class VisualSoundCharacterEffects : MonoBehaviour
{
    Attacker m_Attacker;

    private void Start()
    {
        m_Attacker = GetComponent<Attacker>();
    }

    public void PlayDamageEffects()
    {
        GetComponent<Animator>().SetTrigger("Damage");
        m_Attacker.CanMove = false;
    }

    public void DagameAnimationEnds()
    {
        m_Attacker.CanMove = true;
    }
}
