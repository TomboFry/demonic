using System.Security.Cryptography;
using System.Text;

namespace DeMonic
{
	public struct Server
	{
		public string Host;
		public string Username;
		public string Password;
		public bool UseHTTPS;
		public bool Active;
		public string Salt;

		public static string GenerateSalt()
		{
			RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

			var salt = "";
			while (salt.Length < 6)
			{
				var characters = new byte[1];
				rngCsp.GetBytes(characters);

				var isNumber = characters[0] >= 48 && characters[0] < 58;
				var isUppercase = characters[0] >= 65 && characters[0] <= 90;
				var isLowercase = characters[0] >= 97 && characters[0] <= 122;

				if (isNumber || isUppercase || isLowercase)
				{
					salt += Encoding.ASCII.GetString(characters);
				}
			}

			rngCsp.Dispose();

			return salt;
		}

		private static string GenerateHash(string password, string salt)
		{
			var md5 = MD5.Create();
			var passwordBytes = Encoding.ASCII.GetBytes(password + salt);
			var hashBytes = md5.ComputeHash(passwordBytes);

			// Convert the byte array to hexadecimal string
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < hashBytes.Length; i++)
			{
				builder.Append(hashBytes[i].ToString("X2"));
			}

			md5.Dispose();

			return builder.ToString().ToLower();
		}

		public Server(string host, string username, string password, bool useHTTPS, bool active)
		{
			this.Salt = GenerateSalt();
			this.Password = GenerateHash(password, this.Salt);
			this.Host = host;
			this.Username = username;
			this.UseHTTPS = useHTTPS;
			this.Active = active;
		}

		public Server(string host, string username, string saltedPassword, bool useHTTPS, bool active, string salt)
		{
			this.Host = host;
			this.Username = username;
			this.Password = saltedPassword;
			this.UseHTTPS = useHTTPS;
			this.Active = active;
			this.Salt = salt;
		}
	}
}
