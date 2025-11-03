using GamersCommunity.Core.Exceptions;
using System.Text.RegularExpressions;

namespace MainSite.Consumer.Validators
{
    /// <summary>
    /// Provides validation utilities for user-related fields.
    /// </summary>
    public static class UserValidator
    {
        /// <summary>
        /// Validates a nickname to ensure it only contains alphabetical characters (A–Z, a–z)
        /// and does not exceed 50 characters in length.
        /// </summary>
        /// <param name="nickname">The nickname to validate.</param>
        /// <exception cref="BadRequestException">
        /// Thrown when the nickname is null, empty, too long, or contains invalid characters.
        /// </exception>
        public static void ValidateNickname(string? nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                throw new BadRequestException("Nickname cannot be empty.");

            if (nickname.Length > 50)
                throw new BadRequestException("Nickname must not exceed 50 characters.");

            if (!Regex.IsMatch(nickname, @"^[A-Za-z0-9_-]+$"))
                throw new BadRequestException("Nickname must contain only letters (A–Z, a–z).");
        }
    }
}
