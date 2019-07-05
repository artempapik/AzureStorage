using System.Linq;
using System;

namespace AzureStorage
{
	static class Extensions
	{
		const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

		public static string File(this Uri u) => u.LocalPath.Remove(0, u.LocalPath.LastIndexOf('/') + 1);

		public static string Directory(this Uri u)
		{
			string s = u.LocalPath.Remove(u.LocalPath.LastIndexOf('/'));
			return s.Remove(0, s.LastIndexOf('/') + 1);
		}

		public static bool IsLetter(this char c) => Alphabet.Any(n => n == c);
	}
}