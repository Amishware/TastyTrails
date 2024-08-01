namespace TastyTrails.Common.Interfaces
{
    public interface IUserMetaReader
    {
        /// <summary>
        /// Get user id.
        /// </summary>
        int GetId();

        /// <summary>
        /// Get user's e-mail address
        /// </summary>
        string GetEmail();

        /// <summary>
        /// Get username
        /// </summary>
        string GetUserName();

        /// <summary>
        /// Get user's first and last name.
        /// </summary>
        string GetFullName();
    }
}
