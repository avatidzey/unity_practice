using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float rotationSpeed = 0.5f;
    public bool rotating = false; // Переменная, отслеживающая состояние вращения кубика

    private void Update() {
        if (rotating) RotateCube();
    }
    public void RotateCube() { // Крутим кубик начиная с своей позиции в нужную, определяемую вектором
        gameObject.transform.RotateAround(gameObject.transform.position, rotationVector, rotationSpeed);
    }

    public void FixCubeRotation() { // Устанавливаем положение кубика относительно камеры
        gameObject.transform.rotation = Camera.main.transform.rotation;
    }

    public void FixCubePosition(Vector3 position) { // Позиционирование кубика вначале
        gameObject.transform.position.Set(position.x, position.y, position.z);
    }

    public void AddTexture(Material material) { // Определяем материал для кубика
        gameObject.GetComponent<MeshRenderer>().sharedMaterials.SetValue(material, 0);
    }
}
