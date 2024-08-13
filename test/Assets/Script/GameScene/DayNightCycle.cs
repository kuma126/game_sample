using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight; // ���z�̖������ʂ������C�g
    public Gradient lightColor;    // ���C�g�̐F��ς��邽�߂̃O���f�[�V����
    public Gradient skyboxColor;   // �X�J�C�{�b�N�X�̐F��ς��邽�߂̃O���f�[�V����
    public float dayLength = 60f;  // 1���̒����i�b�P�ʁj

    private float time;

    void Update()
    {
        time += Time.deltaTime / dayLength;
        if (time >= 1)
        {
            time = 0; // ���Ԃ����Z�b�g
        }

        // ���C�g�̉�]���X�V
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f), 170f, 0));

        // ���C�g�̐F���X�V
        directionalLight.color = lightColor.Evaluate(time);

        // �X�J�C�{�b�N�X�̐F���X�V
        RenderSettings.skybox.SetColor("_Tint", skyboxColor.Evaluate(time));
    }
}
