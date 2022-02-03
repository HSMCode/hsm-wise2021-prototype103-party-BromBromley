using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseParticles : MonoBehaviour
{
    // emits confetti like particles if the player wins
    // attached to particle system
    [SerializeField] private ParticleSystem playParticleSystem;
    [SerializeField] private ParticleSystem emitParticleSystem;
    
    private void PlayingParticles(bool on)
    {
        if (on)
        {
            playParticleSystem.Play();
        }
        else if(!on)
        {
            playParticleSystem.Stop();
        }
    }

    public void EmitConfetti()
    {
        emitParticleSystem.Emit(15);
    }
}
