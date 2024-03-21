using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    private bool _enable = true;
    [Range(0, .1f)] private float amplitude = .015f;
    [Range(0, 30)] private float frequency = 10f;

    private Transform _camera = null;
    private Transform cameraHolder = null;

    private float toggleSpeed = 3f;
    private Vector3 startpos;
    private CharacterController controller;

    private void Update()
    {
        if (!enabled) return;

        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        startpos = cameraHolder.localPosition;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        if (!controller.isGrounded) return;

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
