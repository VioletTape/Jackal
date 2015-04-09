namespace Core.Enums {
    public enum PlayerType {
        None,
        Black,
        White,
        Yellow,
        Red
    }

    public class Player {
        private readonly PlayerType playerType;
        public Player(PlayerType playerType) {
            this.playerType = playerType;
        }


    }
}


