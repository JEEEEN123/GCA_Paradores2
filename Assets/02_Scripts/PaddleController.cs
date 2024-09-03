using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Rigidbody boatRigidbody; // 船只的刚体
    public Transform rightController; // 右手手柄的Transform
    public Transform leftController; // 左手手柄的Transform
    public float paddleForceMultiplier = 10f; // 划桨力量的倍增器
    public float waterResistance = 0.99f; // 水面阻力系数

    private Vector3 previousRightPosition;
    private Vector3 previousLeftPosition;

    void Start()
    {
        // 初始化控制器的前一帧位置
        previousRightPosition = rightController.position;
        previousLeftPosition = leftController.position;
    }

    void Update()
    {
        // 计算右手手柄的运动矢量
        Vector3 rightMovement = rightController.position - previousRightPosition;
        // 根据运动矢量施加力到右侧船桨
        ApplyPaddleForce(rightMovement, rightController, true);

        // 计算左手手柄的运动矢量
        Vector3 leftMovement = leftController.position - previousLeftPosition;
        // 根据运动矢量施加力到左侧船桨
        ApplyPaddleForce(leftMovement, leftController, false);

        // 更新控制器的前一帧位置
        previousRightPosition = rightController.position;
        previousLeftPosition = leftController.position;

        // 施加水面阻力
        ApplyWaterResistance();
    }

    void ApplyPaddleForce(Vector3 movement, Transform controller, bool isRight)
    {
        // 根据手柄的运动方向和力量施加力
        Vector3 forceDirection = isRight ? controller.right : -controller.right;
        Vector3 force = forceDirection * -movement.magnitude * paddleForceMultiplier;
        // 将力施加到船上，力的施加点为手柄的位置
        boatRigidbody.AddForceAtPosition(force, controller.position, ForceMode.Impulse);
    }

    void ApplyWaterResistance()
    {
        // 为了模拟水面阻力，每帧减少船只速度
        boatRigidbody.velocity *= waterResistance;
    }
}
