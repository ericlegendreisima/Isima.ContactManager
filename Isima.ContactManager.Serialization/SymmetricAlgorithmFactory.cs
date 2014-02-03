using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Isima.ContactManager.Serialization
{
    internal class SymmetricAlgorithmFactory
    {
        /// <summary>
        /// Initialisation d'un algorithme de cryptage symmétrique avec une chaîne de caractères.
        /// </summary>
        /// <param name="password">Clé d'initialisation de l'algorithme.</param>
        /// <returns>Une nouvelle instance de <see cref="SymmetricAlgorithm"/>.</returns>
        static internal SymmetricAlgorithm Create(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            SymmetricAlgorithm algorithm = TripleDES.Create();

            byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(password);

            byte[] iv = (byte[])Array.CreateInstance(typeof(byte), algorithm.IV.Length);
            Array.Copy(keyBytes, iv, Math.Min(iv.Length, keyBytes.Length));
            // Si nécessaire, complément d'initialisation avec le caractère 128
            for (int i = Math.Min(iv.Length, keyBytes.Length); i < iv.Length; i++)
                iv[i] = 128;

            byte[] key = (byte[])Array.CreateInstance(typeof(byte), algorithm.Key.Length);
            Array.Copy(keyBytes, key, Math.Min(key.Length, keyBytes.Length));
            // Si nécessaire, complément d'initialisation avec le caractère 42
            for (int i = Math.Min(key.Length, keyBytes.Length); i < key.Length; i++)
                key[i] = 42;

            algorithm.IV = iv;
            algorithm.Key = key;

            return algorithm;
        }
    }
}
