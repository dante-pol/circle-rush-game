namespace Root.Assets._Scripts.Gameplay.Player
{
    public class PlayerMovement
    {
        private readonly PlayerModel _player;

        private int _directionRotation;

        public PlayerMovement(PlayerModel player)
        {
            _player = player;
            _directionRotation = 1;
        }

        public void FixedUpdate()
            => Rotate();

        public void ChangeDirection()
            => _directionRotation *= -1;

        private void Rotate()
            => _player.Rigidbody.rotation += _directionRotation * _player.SpeedRotation;
    }
}
