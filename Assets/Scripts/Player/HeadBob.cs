using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public bool _enable = true;
    [Range(0, .1f)] public float amplitude = .015f;
    [Range(0, 30)] public float frequency = 10f;

    public Transform _camera = null;
    public Transform cameraHolder = null;

    private float toggleSpeed = 3f;
    private Vector3 startpos;
    private Rigidbody rb;

    private void Update()
    {
        if (!_enable) return;

        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startpos = cameraHolder.localPosition;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        if (!rb) return;

        PlayMotion(FootStepMotion());
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }
    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency) * amplitude * 2;
        return pos;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == startpos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, startpos, 1 * Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15f;
        return pos;
    }
}
