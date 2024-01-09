using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_2D_EFT : MonoBehaviour
{

    [SerializeField] ParticleSystem particle;
    ParticleSystem.EmitParams emitSettings;

    private void Start()
    {
        emitSettings = new ParticleSystem.EmitParams();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f; // Z 축을 0으로 설정
            emitSettings.position = pos;
            particle.Emit(emitSettings, 1);
        }
    }
}
