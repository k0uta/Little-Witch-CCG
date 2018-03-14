using System.Collections;
using System.Collections.Generic;

static public class BoardManager {

	static public Board Create_Board(CardZone playerDeck1, CardZone playerDeck2){

		var newBoard = new Board();

		newBoard.Player1 = PlayerManager.Create_Player(playerDeck1, "Player1");
		newBoard.Player2 = PlayerManager.Create_Player(playerDeck2, "Player2");
		
		newBoard.CurrentPhase = Board.BoardTurnPhase.Preparation_Phase;
		newBoard.CurrentPlayer = newBoard.Player1;

		return newBoard;

	}

	static public void Change_Phase(Board board, Board.BoardTurnPhase phase){

		board.CurrentPhase = phase;
	}

	static public void Change_Current_Player(Board board){

		board.CurrentPlayer = board.CurrentPlayer == board.Player1 ? board.Player2 : board.Player1;

	}


}
