// RigidbodyVelocityProvider.cs
using UnityEngine;

public class RigidbodyVelocityProvider : IVelocityProvider
{
    private Rigidbody rb;

    public RigidbodyVelocityProvider(Rigidbody rb)
    {
        this.rb = rb;
    }

    public float GetVerticalVelocity()
    {
        return rb.linearVelocity.y;
    }
}