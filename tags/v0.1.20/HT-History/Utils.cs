using System;

namespace HtHistory
{
	public static class Utils
	{
		 public static bool IsRunningOnMono ()
		 {
		    return Type.GetType ("Mono.Runtime") != null;
		 }
	}
}

