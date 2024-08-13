using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight; // 太陽の役割を果たすライト
    public Gradient lightColor;    // ライトの色を変えるためのグラデーション
    public Gradient skyboxColor;   // スカイボックスの色を変えるためのグラデーション
    public float dayLength = 60f;  // 1日の長さ（秒単位）

    private float time;

    void Update()
    {
        time += Time.deltaTime / dayLength;
        if (time >= 1)
        {
            time = 0; // 時間をリセット
        }

        // ライトの回転を更新
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((time * 360f), 170f, 0));

        // ライトの色を更新
        directionalLight.color = lightColor.Evaluate(time);

        // スカイボックスの色を更新
        RenderSettings.skybox.SetColor("_Tint", skyboxColor.Evaluate(time));
    }
}
