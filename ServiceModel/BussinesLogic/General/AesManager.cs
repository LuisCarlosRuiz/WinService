// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the AesManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic.General
{
	using System;
	using System.Configuration;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;

	/// <summary>
	/// The Encrypt and decrypt manager
	/// </summary>
	public class AesManager
	{
		/// <summary>
		/// The data and key vale
		/// </summary>
		private byte[] key;

		/// <summary>
		/// Initializes a new instance of the <see cref="AesManager"/> class.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public AesManager()
		{
			string simpleKey = ConfigurationManager.AppSettings["HashKey"] ?? string.Empty;
			string key64 = System.Convert.ToBase64String((
			new SHA512CryptoServiceProvider())
			.ComputeHash(Encoding.UTF8.GetBytes(simpleKey)))
			.Substring(0, 32);

			key = Encoding.UTF8.GetBytes(key64);
		}

		/// <summary>
		/// Gets the string.
		/// </summary>
		/// <param name="b">The b.</param>
		/// <returns></returns>
		private string GetString(byte[] b) => System.Convert.ToBase64String(b);

		/// <summary>
		/// Gets the bytes.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		private byte[] GetBytes(string s) => System.Convert.FromBase64String(s);

		/// <summary>
		/// Encrypts the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public string Encrypt(string args)
		{
			byte[] data = Encoding.UTF8.GetBytes(args);

			using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
			{
				csp.KeySize = 256;
				csp.BlockSize = 128;
				csp.Key = key;
				csp.Padding = PaddingMode.PKCS7;
				csp.Mode = CipherMode.ECB;
				ICryptoTransform encrypter = csp.CreateEncryptor();
				var EncryptData = encrypter.TransformFinalBlock(data, 0, data.Length);
				return GetString(EncryptData);
			}
		}

		/// <summary>
		/// Decrypts the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public string Decrypt(string args)
		{
			using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
			{
				byte[] data = GetBytes(args);
				csp.KeySize = 256;
				csp.BlockSize = 128;
				csp.Key = key;
				csp.Padding = PaddingMode.PKCS7;
				csp.Mode = CipherMode.ECB;
				ICryptoTransform decrypter = csp.CreateDecryptor();
				var DecryptData = decrypter.TransformFinalBlock(data, 0, data.Length);
				return Encoding.UTF8.GetString(DecryptData);
			}
		}
	}
}
