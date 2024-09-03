using UnityEngine;

public class BoatController1 : MonoBehaviour
{
    public Rigidbody boatRigidbody;
    public Transform rightController;
    public Transform leftController;
    public float forceMultiplier = 10f;
    public float dragCoefficient = 0.5f;

    private Vector3 previousRightPosition;
    private Vector3 previousLeftPosition;

    void Start()
    {
        // 初始化控制器的位置
        previousRightPosition = rightController.localPosition;
        previousLeftPosition = leftController.localPosition;
    }

    void Update()
    {
        // 计算右手控制器的运动矢量
        Vector3 rightMovement = rightController.localPosition - previousRightPosition;
        // 施加右侧划桨的力
        ApplyPaddleForce(rightMovement, rightController);

        // 计算左手控制器的运动矢量
        Vector3 leftMovement = leftController.localPosition - previousLeftPosition;
        // 施加左侧划桨的力
        ApplyPaddleForce(leftMovement, leftController);

        // 更新控制器的前一帧位置
        previousRightPosition = rightController.localPosition;
        previousLeftPosition = leftController.localPosition;

        // 施加水面阻力
        ApplyWaterResistance();
    }

    void ApplyPaddleForce(Vector3 movement, Transform controller)
    {
        // 计算施加的力的大小
        Vector3 force = movement * forceMultiplier;
        // 将力施加在船上，方向是控制器的方向
        boatRigidbody.AddForceAtPosition(force, controller.position);
    }

    void ApplyWaterResistance()
    {
        // 计算水面阻力并施加到船上
        Vector3 dragForce = -dragCoefficient * boatRigidbody.velocity;
        boatRigidbody.AddForce(dragForce);
    }
}
