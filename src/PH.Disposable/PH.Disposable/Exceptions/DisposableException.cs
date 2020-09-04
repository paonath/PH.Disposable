using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace PH.Disposable.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an operation is performed on a disposed object.
    /// </summary>
    /// <seealso cref="System.ObjectDisposedException" />
    public class DisposableException : ObjectDisposedException
    {
        /// <summary>Initializes a new instance of the <see cref="DisposableException"></see> class with serialized data.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected DisposableException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DisposableException"></see> class with a string containing the name of the disposed object.</summary>
        /// <param name="objectName">A string containing the name of the disposed object.</param>
        public DisposableException(string objectName) : base(objectName)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DisposableException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If innerException is not null, the current exception is raised in a catch block that handles the inner exception.</param>
        public DisposableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DisposableException"></see> class with the specified object name and message.</summary>
        /// <param name="objectName">The name of the disposed object.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public DisposableException(string objectName, string message) : base(objectName, message)
        {
        }
    }
}