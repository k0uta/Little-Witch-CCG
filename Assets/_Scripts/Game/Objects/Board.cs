using System.Collections;
using System.Collections.Generic;



public class Board {

	public enum BoardTurnPhase{
		Preparation_Phase,
		Draw_Phase,
		Action_Phase,
		Attack_Phase,
	}

	
	public Player Player1 { get; set; }
	public Player Player2 { get; set; }
	public Player CurrentPlayer { get; set; }
	public BoardTurnPhase CurrentPhase { get; set; }

}
