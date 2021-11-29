using System;

namespace refactorExamination
{
    class Program
	{
		public static void Main(string[] args)
		{
            IDAL DAL = new FileDatabase();
            IUserInterface UI = new ConsoleUI();
            //IGameLogic logic = new BullsAndCows();
            IGameLogic logic = new GuessTheNumber1To100();
            Controller controller = new Controller(DAL, UI, logic);
            controller.Run();
        }
	}
}
