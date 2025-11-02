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
        /// Validates a username to ensure it only contains alphabetical characters (A–Z, a–z)
        /// and does not exceed 50 characters in length.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <exception cref="BadRequestException">
        /// Thrown when the username is null, empty, too long, or contains invalid characters.
        /// </exception>
        public static void ValidateUsername(string? username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new BadRequestException("Username cannot be empty.");

            if (username.Length > 50)
                throw new BadRequestException("Username must not exceed 50 characters.");

            if (!Regex.IsMatch(username, @"^[A-Za-z0-9_-]+$"))
                throw new BadRequestException("Username must contain only letters (A–Z, a–z).");
        }
    }
}
