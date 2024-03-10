using KBCore.Refs;
using UnityEngine;

public class GroundPowerUp : MonoBehaviour {

    [SerializeField] float moveSpeedIncrease = 1f;

    MoveSpeedDecorator powerUp;

    void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player != null) {
            powerUp = new(player, moveSpeedIncrease);
            powerUp.ApplyDecorator();
            Destroy(gameObject);
        }
    }
}
