using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Identity
{
    /// <summary>
    /// Represents an authentication token for a user.
    /// </summary>
    public class IdentityUserToken : Entity
    {
        /// <summary>
        /// Gets or sets the primary key of the user that the token belongs to.
        /// </summary>
        public virtual string UserId { get; protected set; }

        /// <summary>
        /// Gets or sets the LoginProvider this token is from.
        /// </summary>
        public virtual string LoginProvider { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the token.
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the token value.
        /// </summary>
        public virtual string Value { get; set; }

        protected IdentityUserToken()
        {
            
        }

        public IdentityUserToken([NotNull] string userId, [NotNull] string loginProvider, [NotNull] string name, string value) //TODO: Can value be null?
        {
            Check.NotNull(userId, nameof(userId));
            Check.NotNull(loginProvider, nameof(loginProvider));
            Check.NotNull(name, nameof(name));

            UserId = userId;
            LoginProvider = loginProvider;
            Name = name;
            Value = value;
        }
    }
}