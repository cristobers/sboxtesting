using Sandbox;

namespace commands
{
	class Commands // These are console commands
	{
		[ServerCmd( "clearprops" )]
		public static void clearprops()
		{
			Sandbox.Log.Info( "this'll clear props some day" );
		}
	}
}
