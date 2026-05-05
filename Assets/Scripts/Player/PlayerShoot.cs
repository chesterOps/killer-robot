

public class PlayerShoot : Shoot
{
    private PlayerInputController _playerInputController;

    void Awake()
    {
        _playerInputController = FindAnyObjectByType<PlayerInputController>();
        _playerInputController.OnAttackButtonPressed += Shoot;
    }

    void Shoot()
    {
        FireBullet(transform);
    }

}
