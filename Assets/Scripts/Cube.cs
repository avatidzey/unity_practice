using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool imRotating = false;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] Vector3 rotation;


    private void Update() {
        if (imRotating) {
            RotateCube();
        }
    }
    public void RotateCube() { // Крутим кубик начиная с своей позиции в нужную, определяемую вектором
        gameObject.transform.RotateAround(gameObject.transform.position, rotation, rotationSpeed);
    }

    public void FixCubePosition(Vector3 position) { // Позиционирование кубика вначале
        gameObject.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(position.x, position.y, 5f));
    }

    public void AddTexture(Material material) { // Определяем материал для кубика
        gameObject.GetComponent<MeshRenderer>().sharedMaterials.SetValue(material, 0);
    }

}
